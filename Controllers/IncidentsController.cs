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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var incident = await _context.Incidents.FindAsync(id);

        if (incident == null)
            return NotFound();

        return Ok(incident);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Incident incident)
    {
        _context.Incidents.Add(incident);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = incident.Id }, incident);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Incident updatedIncident)
    {
        var incident = await _context.Incidents.FindAsync(id);

        if (incident == null)
            return NotFound();

        incident.Title = updatedIncident.Title;
        incident.Severity = updatedIncident.Severity;
        incident.Status = updatedIncident.Status;

        await _context.SaveChangesAsync();

        return Ok(incident);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var incident = await _context.Incidents.FindAsync(id);

        if (incident == null)
            return NotFound();

        _context.Incidents.Remove(incident);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}