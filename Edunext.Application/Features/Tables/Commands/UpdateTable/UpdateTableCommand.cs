using MediatR;

namespace Edunext.Application.Features.Tables.Commands.UpdateTable;

public record UpdateTableCommand(Guid TableId, string Code) : IRequest<Unit>;