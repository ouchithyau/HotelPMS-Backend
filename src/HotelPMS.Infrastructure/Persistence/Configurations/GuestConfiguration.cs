using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Infrastructure.Persistence.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.FullName).IsRequired().HasMaxLength(150);
        builder.Property(g => g.Email).HasMaxLength(150);
        builder.Property(g => g.PhoneNumber).IsRequired().HasMaxLength(50);
        builder.Property(g => g.IdentificationNumber).IsRequired().HasMaxLength(50);
    }
}