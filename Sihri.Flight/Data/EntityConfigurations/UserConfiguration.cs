using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sihri.Flight.Domain;

namespace Sihri.Visa.Data.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(o => o.ReservedFlightsCollection).WithOne(o => o.AppliedByUser).HasForeignKey(o => o.UserId);
    }
}