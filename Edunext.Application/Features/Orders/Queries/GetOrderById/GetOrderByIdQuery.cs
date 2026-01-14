using Edunext.Application.DTOs.Order;
using MediatR;

namespace Edunext.Application.Features.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid OrderId) : IRequest<OrderDto?>;

