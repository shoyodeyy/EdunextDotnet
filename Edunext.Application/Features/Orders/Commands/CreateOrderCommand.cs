using MediatR;

namespace Edunext.Application.Features.Orders.Commands;

public record CreateOrderCommand(Guid TableId): IRequest<Guid>;