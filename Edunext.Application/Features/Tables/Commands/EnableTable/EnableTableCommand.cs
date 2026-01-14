using MediatR;

namespace Edunext.Application.Features.Tables.Commands.EnableTable;

public record EnableTableCommand(Guid TableId) : IRequest<Unit>;