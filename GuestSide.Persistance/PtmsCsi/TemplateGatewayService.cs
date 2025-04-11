using System.Text;
using System.Text.Json;
using Core.Persistance.Models;

namespace Core.Persistance.PtmsCsi;
public class TemplateGatewayService : ITemplateGatewayService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "http://api.logixplore.com:7777/api/templates";

    public TemplateGatewayService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetAllAsync(string? type, string? language)
    {
        var url = $"{_baseUrl}?type={type}&language={language}";
        var response = await _httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetByKeyAsync(string key, string? language)
    {
        var url = $"{_baseUrl}/{key}?language={language}";
        var response = await _httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> CreateAsync(Template template)
    {
        var content = new StringContent(JsonSerializer.Serialize(template), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_baseUrl, content);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> UpdateAsync(string id, Template template)
    {
        var content = new StringContent(JsonSerializer.Serialize(template), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", content);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<(byte[] File, string ContentType, string FileName)> RenderTemplateAsFileAsync(TemplateRenderRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_baseUrl}/render-file", content);

        var bytes = await response.Content.ReadAsByteArrayAsync();
        var contentType = response.Content.Headers.ContentType?.ToString() ?? "text/html";
        var fileName = response.Content.Headers.ContentDisposition?.FileName?.Trim('"') ?? "template.html";

        return (bytes, contentType, fileName);
    }
}