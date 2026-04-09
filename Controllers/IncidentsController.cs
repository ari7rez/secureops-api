using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureOpsAPI.Data;
using SecureOpsAPI.Models;

namespace SecureOpsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public IncidentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var incidents = await _context.Incidents.ToListAsync();
        return Ok(incidents);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Incident incident)
    {
        _context.Incidents.Add(incident);
        await _context.SaveChangesAsync();
        return Ok(incident);
    }
}