using MediatR;

namespace Edunext.Application.Features.Orders.Commands.RemoveOrderItem;

public record RemoveOrderItemCommand(Guid OrderId, Guid OrderItemId) : IRequest<Unit>; 