using HotelPMS.Domain.Common;

namespace HotelPMS.Domain.Entities;

public class RoomType : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty; // Single, Double, Suite, Deluxe
    public string Description { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public int MaxAdults { get; set; }
    public int MaxChildren { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}