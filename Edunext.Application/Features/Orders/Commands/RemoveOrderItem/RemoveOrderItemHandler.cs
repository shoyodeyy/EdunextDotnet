using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
using MediatR;

namespace Edunext.Application.Features.Orders.Commands.RemoveOrderItem;

public class RemoveOrderItemHandler : IRequestHandler<RemoveOrderItemCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveOrderItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            throw new NotFoundException($"Order {request.OrderId} not found");
        }
        
        var orderItem = await _unitOfWork.OrderItems.GetByIdAsync(request.OrderItemId);
        if (orderItem == null)
        {
            throw new NotFoundException($"Order item {request.OrderItemId} not found");
        }

        if (orderItem.OrderId != request.OrderId)
        {
            throw new ValidationException("Order item doesn't belong to this order");
        }
        
        order.RemoveItem(orderItem.OrderId);
        
        _unitOfWork.OrderItems.Delete(orderItem);
        _unitOfWork.Orders.Update(order);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}