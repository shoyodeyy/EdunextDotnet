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
        // 1. Lấy Order
        var order = await _unitOfWork.Orders.GetByIdAsync(request.OrderId);
        if (order == null)
            throw new KeyNotFoundException($"Order {request.OrderId} not found");

        // 2. Lấy MenuItem để lấy thông tin
        var menuItem = await _unitOfWork.Menus.GetByIdAsync(request.MenuItemId);
        if (menuItem == null)
            throw new KeyNotFoundException($"Menu item {request.MenuItemId} not found");

        if (!menuItem.IsAvailable)
            throw new InvalidOperationException("Menu item is not available");

        // 3. Tạo OrderItem
        var orderItem = new OrderItem(
            menuItem.Id,
            menuItem.Name,
            menuItem.Price,
            request.Quantity,
            request.Note
        );

        // 4. Add item vào order (sử dụng method trong entity)
        order.AddItem(orderItem);

        // 5. Update và save
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}