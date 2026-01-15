using Edunext.Application.DTOs.Table;
using MediatR;

namespace Edunext.Application.Features.Tables.Queries.GetAllTables;

public record GetAllTablesQuery(bool? IsActive = null) : IRequest<IEnumerable<TableDto>>;