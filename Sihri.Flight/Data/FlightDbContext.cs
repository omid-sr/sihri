using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sihri.Flight.Domain;

namespace Sihri.Flight.Data;

public class FlightDbContext : IdentityDbContext<User, Role, Guid>
{
    public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
    {
    }
    public DbSet<ReservedFlights> ReservedFlights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
