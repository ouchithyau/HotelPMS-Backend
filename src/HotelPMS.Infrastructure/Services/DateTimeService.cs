using HotelPMS.Application.Common.Interfaces;

namespace HotelPMS.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}