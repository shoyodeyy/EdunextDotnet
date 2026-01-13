

using Edunext.Application.DTOs.Order;
using Edunext.Core.Interfaces;
using MediatR;

namespace Edunext.Application.Features.Orders.Queries.GetActiveOrder;

public class GetActiveOrderHandler : IRequestHandler<GetActiveOrderQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepo;

    public GetActiveOrderHandler(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<OrderDto> Handle(GetActiveOrderQuery request, CancellationToken ct)
    {
        var order = await _orderRepo.GetActiveByTableAsync(request.TableId);

        if (order == null) return null;

        return new OrderDto
        {
            OrderId = order.Id,
            TableId = order.TableId,
            Status = order.Status.ToString(),
            TotalPrice = order.TotalPrice,
            Items = order.Items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                Name = i.MenuItemName,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity,
                TotalPrice = i.TotalPrice,
                Note = i.Note,
            }).ToList(),
        };
    }
}
