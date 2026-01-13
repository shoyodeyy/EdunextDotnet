using MediatR;

namespace Edunext.Application.Features.Orders.Commands.AddItemToOrder;

public record AddItemToOrderCommand(
    Guid OrderId,
    Guid MenuItemId,
    int Quantity,
    string? Note
) : IRequest<Unit>;