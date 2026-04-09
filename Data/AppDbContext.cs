using Microsoft.EntityFrameworkCore;
using SecureOpsAPI.Models;

namespace SecureOpsAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<Risk> Risks => Set<Risk>();
}