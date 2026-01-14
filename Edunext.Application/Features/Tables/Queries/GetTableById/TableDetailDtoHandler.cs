using Edunext.Application.Abstractions.Persistence;
using MediatR;

namespace Edunext.Application.Features.Tables.Queries.GetTableById;

public class TableDetailDtoHandler: IRequestHandler<GetTableByIdQuery, TableDetailDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public TableDetailDtoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TableDetailDto?> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWork.Tables.GetByIdAsync(request.TableId);
        
        return table == null ? null : new TableDetailDto(table.Id, table.Code, table.IsActive);
    }
}