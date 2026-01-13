using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Features.Tables.Commands.CreateTable;
using Edunext.Core.Entities;
using MediatR;

namespace Edunext.Application.Features.Tables.Commands.UpdateTable;

public class UpdateTableHandler:IRequestHandler<UpdateTableCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTableHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWork.Tables.GetByIdAsync(request.TableId);
        if (table == null)
        {
            throw new KeyNotFoundException($"Table '{request.TableId}' not found.");
        }
        
        var existingTable = await _unitOfWork.Tables.GetByCodeAsync(request.Code);
        if (existingTable != null && existingTable.Id != request.TableId)
        {
            throw new InvalidOperationException($"Table with code '{request.Code}' already exists.");
        }
        
        table?.UpdateCode(request.Code);

        if (table != null) _unitOfWork.Tables.Update(table);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}