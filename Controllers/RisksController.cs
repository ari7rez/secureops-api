using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureOpsAPI.Data;
using SecureOpsAPI.Models;

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
        return Ok(await _context.Risks.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Risk risk)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Risks.Add(risk);
        await _context.SaveChangesAsync();

        return Ok(risk);
    }
}