using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sihri.Visa.Domain;

namespace Sihri.Visa.Data;

public class VisaDbContext : IdentityDbContext<User, Role, Guid>
{
    public VisaDbContext(DbContextOptions<VisaDbContext> options) : base(options)
    {
    }
    public DbSet<AppliedVisa> AppliedVisas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
