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
        return await _httpClient.GetFromJsonAsync<List<Incident>>("api/incidents") ?? new();
    }

    public async Task CreateIncidentAsync(Incident incident)
    {
        await _httpClient.PostAsJsonAsync("api/incidents", incident);
    }
}