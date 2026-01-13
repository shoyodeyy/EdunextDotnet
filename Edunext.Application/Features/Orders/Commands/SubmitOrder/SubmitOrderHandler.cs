using Edunext.Application.Abstractions.Persistence;
using MediatR;

namespace Edunext.Application.Features.Orders.Commands.SubmitOrder;

public class SubmitOrderHandler : IRequestHandler<SubmitOrderCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubmitOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
        if (order == null)
            throw new KeyNotFoundException($"Order {request.OrderId} not found");

        // ✅ Gọi domain method
        order.Submit();

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}