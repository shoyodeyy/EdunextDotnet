using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
using Edunext.Core.Entities;
using Edunext.Core.Enums;
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
            throw new NotFoundException($"Order {request.OrderId} not found");

        if (order.Status == OrderStatus.Paid)
        {
            throw new ValidationException("Cannot modify a paid order");
        }

        var menuItem = await _unitOfWork.Menus.GetByIdAsync(request.MenuItemId);
        if (menuItem == null)
            throw new NotFoundException($"Menu item {request.MenuItemId} not found");

        if (!menuItem.IsAvailable)
            throw new ValidationException("Menu item is out of stock");

        if (request.Quantity <= 0)
        {
            throw new ValidationException("Quantity must be greater than 0");
        }

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
        _unitOfWork.Orders.Update(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}