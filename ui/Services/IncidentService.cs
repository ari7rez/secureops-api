using System.Net.Http.Json;
using SecureOpsUI.Models;

namespace SecureOpsUI.Services;

public class IncidentService
{
    private readonly HttpClient _httpClient;

    public IncidentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Incident>> GetIncidentsAsync()
    {
        var incidents = await _httpClient.GetFromJsonAsync<List<Incident>>("api/incidents");
        return incidents ?? new List<Incident>();
    }
}