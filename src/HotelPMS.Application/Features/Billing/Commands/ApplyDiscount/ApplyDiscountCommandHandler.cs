using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelPMS.Application.Features.Billing.Commands.ApplyDiscount;

public class ApplyDiscountCommandHandler : IRequestHandler<ApplyDiscountCommand, bool>
{
    public async Task<bool> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
    {
        // 1. Find the booking
        // 2. Subtract DiscountAmount from TotalAmount
        // 3. Save changes

        await Task.CompletedTask;
        return true;
    }
}