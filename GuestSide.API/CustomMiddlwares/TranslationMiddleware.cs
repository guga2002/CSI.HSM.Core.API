using System.Text;
using Csi.VoicePack;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;

public class TranslationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly CsiVoicePack _translatorService;
    private readonly IDistributedCache _cache;

    public TranslationMiddleware(RequestDelegate next, CsiVoicePack translatorService, IDistributedCache cache)
    {
        _next = next;
        _translatorService = translatorService;
        _cache = cache;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestedLanguage = context.Request.Headers["Accept-Language"].FirstOrDefault()?.ToLower() ?? "en";

        if (requestedLanguage is "en" or "en-us" or "us-en" or "us" or "en-gb" or "gb-en" or "gb")
        {
            await _next(context);
            return;
        }

        var originalBodyStream = context.Response.Body;
        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        try
        {
            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(memoryStream).ReadToEndAsync();

            if (!string.IsNullOrWhiteSpace(responseText))
            {
                string translatedResponse = await TranslateResponse(responseText, requestedLanguage);
                byte[] responseBytes = Encoding.UTF8.GetBytes(translatedResponse);

                context.Response.ContentLength = responseBytes.Length;
                context.Response.Body = originalBodyStream;
                await context.Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);
            }
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private async Task<string> TranslateResponse(string responseText, string targetLanguage)
    {
        if (responseText.Trim().StartsWith("{") || responseText.Trim().StartsWith("["))
        {
            var jsonObject = JObject.Parse(responseText);
            await TranslateJsonObject(jsonObject, targetLanguage);
            return jsonObject.ToString();
        }

        return await GetOrTranslate(responseText, targetLanguage);
    }

    private async Task TranslateJsonObject(JObject jsonObject, string targetLanguage)
    {
        var properties = jsonObject.Properties().ToList(); // 🛡️ Snapshot at the beginning

        foreach (var property in properties)
        {
            var value = property.Value;

            if (value.Type == JTokenType.String)
            {
                string originalText = value.ToString();
                string translatedText = await GetOrTranslate(originalText, targetLanguage);
                property.Value = translatedText;
            }
            else if (value.Type == JTokenType.Object)
            {
                await TranslateJsonObject((JObject)value, targetLanguage);
            }
            else if (value.Type == JTokenType.Array)
            {
                var array = (JArray)value;

                for (int i = 0; i < array.Count; i++)
                {
                    var item = array[i];

                    if (item.Type == JTokenType.String)
                    {
                        string originalText = item.ToString();
                        string translatedText = await GetOrTranslate(originalText, targetLanguage);
                        array[i] = translatedText;
                    }
                    else if (item.Type == JTokenType.Object)
                    {
                        await TranslateJsonObject((JObject)item, targetLanguage);
                    }
                }
            }
        }
    }


    private async Task<string> GetOrTranslate(string text, string targetLanguage)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        string cacheKey = $"translation:en:{targetLanguage}:{text}";
        string cachedTranslation = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedTranslation))
        {
            return cachedTranslation;
        }

        var translatedText = await _translatorService.TranslateAsync(new TranslationModelLoc
        {
            From = "en",
            Text = text,
            To = targetLanguage
        });

        await _cache.SetStringAsync(cacheKey, translatedText.Data.TranslatedText, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
        });

        return translatedText.Data.TranslatedText;
    }
}
