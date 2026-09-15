using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Infrastructure.Persistence.Configurations;

public class HousekeepingTaskConfiguration : IEntityTypeConfiguration<HousekeepingTask>
{
    public void Configure(EntityTypeBuilder<HousekeepingTask> builder)
    {
        builder.HasKey(hkt => hkt.Id);
        builder.HasOne(hkt => hkt.Room)
            .WithMany(r => r.HousekeepingTasks)
            .HasForeignKey(hkt => hkt.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}