using MediatR;

namespace HotelPMS.Application.Features.Guests.Commands.VerifyDocument;

public record VerifyGuestDocumentCommand(
    Guid GuestId,
    string DocumentType,
    string DocumentNumber,
    string IssuedCountry,
    DateTime ExpiryDate,
    string ScannedImageUrlOrData
) : IRequest<bool>;