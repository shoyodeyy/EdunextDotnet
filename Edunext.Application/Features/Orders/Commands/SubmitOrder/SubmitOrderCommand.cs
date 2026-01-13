using MediatR;

namespace Edunext.Application.Features.Orders.Commands.SubmitOrder;

public record SubmitOrderCommand(Guid OrderId) : IRequest<Unit>;