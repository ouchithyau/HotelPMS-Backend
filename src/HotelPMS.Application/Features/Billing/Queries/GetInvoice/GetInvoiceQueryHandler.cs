using MediatR;
using HotelPMS.Application.DTOs;

namespace HotelPMS.Application.Features.Billing.Queries.GetInvoice;

public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, InvoiceDto>
{
    public async Task<InvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        // 1. Fetch booking, guest, room, and extra services from DB
        // 2. Map data to InvoiceDto

        await Task.CompletedTask;
        return new InvoiceDto
        {
            BookingId = request.BookingId,
            BookingReference = "BK-1001",
            GuestName = "John Doe",
            RoomNumber = "101",
            RoomCharges = 150.00m,
            ExtraServicesTotal = 30.00m,
            TotalAmount = 180.00m,
            PaymentStatus = "Paid"
        };
    }
}