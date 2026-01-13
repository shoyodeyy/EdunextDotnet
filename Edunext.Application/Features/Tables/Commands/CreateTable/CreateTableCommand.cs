using MediatR;

namespace Edunext.Application.Features.Tables.Commands.CreateTable;

public record CreateTableCommand(string Code) : IRequest<Guid>;