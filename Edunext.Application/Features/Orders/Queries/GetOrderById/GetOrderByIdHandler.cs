using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.DTOs.Order;
using MediatR;

namespace Edunext.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderRepository _orderRepo;

    public GetOrderByIdHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken ct)
    {
        var order = await _orderRepo.GetByIdAsync(request.OrderId);

        if (order == null) return null;

        return new OrderDto
        {
            OrderId = order.Id,
            TableId = order.TableId,
            Status = order.Status.ToString(),
            TotalPrice = order.TotalPrice,
            Items = order.Items.Select(i => new OrderItemDto
            {
                OrderItemId = i.Id,
                MenuItemId = i.MenuItemId,
                Name = i.MenuItemName,
                MenuItemName = i.MenuItemName,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity,
                TotalPrice = i.TotalPrice,
                Note = i.Note,
            }).ToList(),
        };
    }
}

