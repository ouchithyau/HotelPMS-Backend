using MediatR;

namespace HotelPMS.Application.Features.Billing.Commands.CityLedger;

public record TransferToCityLedgerCommand(
    Guid ReservationId,
    string CompanyName,
    string LPOReferenceNumber, // Local Purchase Order or Corporate Reference
    decimal Amount
) : IRequest<bool>;