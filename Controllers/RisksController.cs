using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureOpsAPI.Data;
using SecureOpsAPI.Models;
using SecureOpsAPI.Models.Requests;

namespace SecureOpsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RisksController : ControllerBase
{
    private readonly AppDbContext _context;

    public RisksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var risks = await _context.Risks
            .Include(r => r.Incidents)
            .ToListAsync();

        return Ok(risks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var risk = await _context.Risks
            .Include(r => r.Incidents)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (risk == null)
            return NotFound();

        return Ok(risk);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRiskRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var risk = new Risk
        {
            Title = request.Title,
            Severity = request.Severity,
            Owner = request.Owner,
            Status = request.Status
        };

        _context.Risks.Add(risk);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = risk.Id }, risk);
    }
}