using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
using Edunext.Core.Enums;
using MediatR;

namespace Edunext.Application.Features.Orders.Commands.CompleteOrder;

public record CompleteOrderCommand(Guid OrderId) : IRequest<Unit>;

public class CompleteOrderHandler : IRequestHandler<CompleteOrderCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CompleteOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
        if (order == null)
            throw new NotFoundException($"Order {request.OrderId} not found");

        if (order.Status != OrderStatus.Cooking)
        {
            throw new ValidationException("Cannot complete order");
        }
        
        order.Complete();

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}