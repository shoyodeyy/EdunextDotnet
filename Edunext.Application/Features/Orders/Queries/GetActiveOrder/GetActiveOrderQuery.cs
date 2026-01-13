using Edunext.Application.DTOs.Order;
using MediatR;

namespace Edunext.Application.Features.Orders.Queries.GetActiveOrder;

public record GetActiveOrderQuery(Guid TableId) : IRequest<OrderDto?>;
