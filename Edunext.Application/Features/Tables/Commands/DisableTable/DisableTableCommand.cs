using MediatR;

namespace Edunext.Application.Features.Tables.Commands.DisableTable;

public record DisableTableCommand(Guid TableId) : IRequest<Unit>;