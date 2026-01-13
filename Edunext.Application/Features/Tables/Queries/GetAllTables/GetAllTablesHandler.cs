using Edunext.Application.Abstractions.Persistence;
using MediatR;

namespace Edunext.Application.Features.Tables.Queries.GetAllTables;

public class GetAllTablesHandler : IRequestHandler<GetAllTablesQuery, IEnumerable<TableDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTablesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<TableDto>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
    {
        var tables = await _unitOfWork.Tables.GetAllAsync(request.IsActive);

        return tables.Select(t => new TableDto(t.Id, t.Code, t.IsActive)).ToList();
    }
}