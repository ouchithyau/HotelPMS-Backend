using HotelPMS.Application.Common.Interfaces;
using HotelPMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelPMS.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<SeasonPricing> SeasonPricing => Set<SeasonPricing>();
    public DbSet<ExtraService> ExtraServices => Set<ExtraService>();
    public DbSet<BookingService> BookingServices => Set<BookingService>();
    public DbSet<HousekeepingTask> HousekeepingTasks => Set<HousekeepingTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}