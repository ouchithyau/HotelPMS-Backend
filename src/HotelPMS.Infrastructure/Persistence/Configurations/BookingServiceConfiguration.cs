using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Infrastructure.Persistence.Configurations;

public class BookingServiceConfiguration : IEntityTypeConfiguration<BookingService>
{
    public void Configure(EntityTypeBuilder<BookingService> builder)
    {
        builder.HasKey(bs => bs.Id);
        builder.Property(bs => bs.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(bs => bs.TotalPrice).HasColumnType("decimal(18,2)");
        builder.HasOne(bs => bs.Booking)
            .WithMany(b => b.BookingServices)
            .HasForeignKey(bs => bs.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(bs => bs.ExtraService)
            .WithMany(es => es.BookingServices)
            .HasForeignKey(bs => bs.ExtraServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}