using Microsoft.EntityFrameworkCore;
using HotelPMS.Domain.Entities;

namespace HotelPMS.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<RoomType> RoomTypes { get; }
    DbSet<Room> Rooms { get; }
    DbSet<Guest> Guests { get; }
    DbSet<Booking> Bookings { get; }
    DbSet<SeasonPricing> SeasonPricing { get; }
    DbSet<ExtraService> ExtraServices { get; }
    DbSet<BookingService> BookingServices { get; }
    DbSet<HousekeepingTask> HousekeepingTasks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}