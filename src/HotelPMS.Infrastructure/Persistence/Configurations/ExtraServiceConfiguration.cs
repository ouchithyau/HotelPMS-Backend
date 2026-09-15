using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Infrastructure.Persistence.Configurations;

public class ExtraServiceConfiguration : IEntityTypeConfiguration<ExtraService>
{
    public void Configure(EntityTypeBuilder<ExtraService> builder)
    {
        builder.HasKey(es => es.Id);
        builder.Property(es => es.ServiceName).IsRequired().HasMaxLength(150);
        builder.Property(es => es.UnitPrice).HasColumnType("decimal(18,2)");
    }
}