using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureOpsAPI.Data;
using SecureOpsAPI.Models;
using SecureOpsAPI.Models.Requests;

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
        var incidents = await _context.Incidents
            .Include(i => i.Risk)
            .ToListAsync();

        return Ok(incidents);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var incident = await _context.Incidents
            .Include(i => i.Risk)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (incident == null)
            return NotFound();

        return Ok(incident);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateIncidentRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (request.RiskId.HasValue)
        {
            var exists = await _context.Risks.AnyAsync(r => r.Id == request.RiskId);
            if (!exists)
                return BadRequest(new { message = "Invalid RiskId" });
        }

        var incident = new Incident
        {
            Title = request.Title,
            Severity = request.Severity,
            Status = request.Status,
            RiskId = request.RiskId
        };

        _context.Incidents.Add(incident);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = incident.Id }, incident);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Incident updatedIncident)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var incident = await _context.Incidents.FindAsync(id);

        if (incident == null)
            return NotFound();

        if (updatedIncident.RiskId.HasValue)
        {
            var riskExists = await _context.Risks.AnyAsync(r => r.Id == updatedIncident.RiskId.Value);
            if (!riskExists)
                return BadRequest(new { message = "Invalid RiskId. Risk does not exist." });
        }

        incident.Title = updatedIncident.Title;
        incident.Severity = updatedIncident.Severity;
        incident.Status = updatedIncident.Status;
        incident.RiskId = updatedIncident.RiskId;

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