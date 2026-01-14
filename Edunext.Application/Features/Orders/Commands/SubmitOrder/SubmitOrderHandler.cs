using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
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
            throw new NotFoundException($"Order {request.OrderId} not found");

        if (!order.Items.Any())
        {
            throw new ValidationException("Cannot submit empty order");
        }

        order.Submit();

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}