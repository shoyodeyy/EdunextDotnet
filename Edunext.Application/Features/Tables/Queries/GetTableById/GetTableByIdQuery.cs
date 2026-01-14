using MediatR;

namespace Edunext.Application.Features.Tables.Queries.GetTableById;

public record GetTableByIdQuery(Guid TableId) : IRequest<TableDetailDto?>;