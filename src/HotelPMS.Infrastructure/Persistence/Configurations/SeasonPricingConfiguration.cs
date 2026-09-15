using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Infrastructure.Persistence.Configurations;

public class SeasonPricingConfiguration : IEntityTypeConfiguration<SeasonPricing>
{
    public void Configure(EntityTypeBuilder<SeasonPricing> builder)
    {
        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.SeasonName).IsRequired().HasMaxLength(100);
        builder.Property(sp => sp.PriceMultiplier).HasColumnType("decimal(18,2)");
    }
}