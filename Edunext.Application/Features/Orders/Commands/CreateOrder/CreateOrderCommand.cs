using MediatR;

namespace Edunext.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid TableId): IRequest<Guid>;