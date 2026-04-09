using System.Net.Http.Json;
using SecureOpsUI.Models;

namespace SecureOpsUI.Services;

public class RiskService
{
    private readonly HttpClient _httpClient;

    public RiskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Risk>> GetRisksAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Risk>>("api/risks") ?? new();
    }

    public async Task<bool> CreateRiskAsync(Risk risk)
    {
        var response = await _httpClient.PostAsJsonAsync("api/risks", risk);
        return response.IsSuccessStatusCode;
    }
}