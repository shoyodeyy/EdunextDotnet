using MediatR;

namespace Edunext.Application.Features.Tables.Commands;

public record DisableTableCommand(Guid TableId) : IRequest<Unit>;