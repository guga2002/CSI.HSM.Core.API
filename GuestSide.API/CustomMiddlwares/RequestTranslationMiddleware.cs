using Csi.VoicePack;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Core.API.CustomMiddlwares
{
    public class RequestTranslationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CsiVoicePack _translatorService;
        private readonly IDistributedCache _cache;

        public RequestTranslationMiddleware(RequestDelegate next, CsiVoicePack translatorService, IDistributedCache cache)
        {
            _next = next;
            _translatorService = translatorService;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestedLanguage = context.Request.Headers["Accept-Language"].FirstOrDefault()?.ToLower() ?? "en";

            if (requestedLanguage.StartsWith("en"))
            {
                await _next(context);
                return;
            }

            if (context.Request.ContentType?.Contains("application/json") != true)
            {
                await _next(context);
                return;
            }

            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();

            if (string.IsNullOrWhiteSpace(body))
            {
                context.Request.Body.Position = 0;
                await _next(context);
                return;
            }

            JObject requestJson = JObject.Parse(body);
            await TranslateJsonObject(requestJson, requestedLanguage);

            var translatedBody = Encoding.UTF8.GetBytes(requestJson.ToString());
            context.Request.Body = new MemoryStream(translatedBody);
            context.Request.Body.Seek(0, SeekOrigin.Begin);

            await _next(context);
        }

        private async Task TranslateJsonObject(JObject jsonObject, string sourceLanguage)
        {
            foreach (var property in jsonObject.Properties().ToList()) 
            {
                if (property.Name.Equals("languageCode", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (property.Value.Type == JTokenType.String)
                {
                    string originalText = property.Value.ToString();
                    string translatedText = await GetOrTranslate(originalText, sourceLanguage);
                    property.Value = translatedText;
                }
                else if (property.Value.Type == JTokenType.Object)
                {
                    await TranslateJsonObject((JObject)property.Value, sourceLanguage);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    foreach (var item in (JArray)property.Value)
                    {
                        if (item.Type == JTokenType.String)
                        {
                            string originalText = item.ToString();
                            string translatedText = await GetOrTranslate(originalText, sourceLanguage);
                            item.Replace(translatedText);
                        }
                        else if (item.Type == JTokenType.Object)
                        {
                            await TranslateJsonObject((JObject)item, sourceLanguage);
                        }
                    }
                }
            }
        }

        private async Task<string> GetOrTranslate(string text, string sourceLanguage)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string cacheKey = $"translation:{sourceLanguage}:en:{text}";
            string cachedTranslation = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedTranslation))
                return cachedTranslation;

            var translatedText = await _translatorService.Gpt2Async(new TranslateUsingAi
            {
                DestinyCountry = "English",
                Text = text
            });

            await _cache.SetStringAsync(cacheKey, translatedText.Data.TranslatedText, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            });

            return translatedText.Data.TranslatedText;
        }
    }
}
