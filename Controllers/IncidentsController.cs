using Microsoft.AspNetCore.Mvc;
using SecureOpsAPI.Models;

namespace SecureOpsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : ControllerBase
{
    private static readonly List<Incident> incidents = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(incidents);
    }

    [HttpPost]
    public IActionResult Create(Incident incident)
    {
        incident.Id = incidents.Count + 1;
        incidents.Add(incident);
        return Ok(incident);
    }
}