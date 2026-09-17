namespace HotelPMS.Application.DTOs;

public class DocumentVerificationDto
{
    public Guid GuestId { get; set; }
    public string DocumentType { get; set; } = string.Empty; // e.g., "Passport", "NationalID"
    public string DocumentNumber { get; set; } = string.Empty;
    public string IssuedCountry { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public bool IsVerified { get; set; }
    public DateTime VerifiedAt { get; set; }
}