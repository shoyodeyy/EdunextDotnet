using Edunext.Application.DTOs.Order;
using MediatR;

namespace Edunext.Application.Features.Orders.Queries.GetAllOrder;

public record GetAllOrderQuery() : IRequest<List<OrderDto>>;
