using Edunext.Application.Abstractions.Persistence;
using Edunext.Core.Entities;
using MediatR;

namespace Edunext.Application.Features.Orders.Commands.AddItemToOrder;

public class AddItemToOrderHandler : IRequestHandler<AddItemToOrderCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddItemToOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
        if (order == null)
            throw new KeyNotFoundException($"Order {request.OrderId} not found");

        var menuItem = await _unitOfWork.Menus.GetByIdAsync(request.MenuItemId);
        if (menuItem == null)
            throw new KeyNotFoundException($"Menu item {request.MenuItemId} not found");

        if (!menuItem.IsAvailable)
            throw new InvalidOperationException("Menu item is not available");

        var orderItem = new OrderItem(
            order.Id,
            menuItem.Id,
            menuItem.Name,
            menuItem.Price,
            request.Quantity,
            request.Note
        );

        order.AddItem(orderItem);
        
        await _unitOfWork.OrderItems.AddAsync(orderItem);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}