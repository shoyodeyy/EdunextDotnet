using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.Features.Orders.Queries.GetAllOrder;


public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, List<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken ct)
    {
        var orders = await _orderRepository.GetAllOrderAsync();
        return orders.Select(order => new OrderDto
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
        }).ToList();
    }
}
