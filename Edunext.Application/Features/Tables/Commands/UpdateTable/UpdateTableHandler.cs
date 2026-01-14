using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
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
            throw new NotFoundException($"Table '{request.TableId}' not found.");
        }
        
        var existingTable = await _unitOfWork.Tables.GetByCodeAsync(request.Code);
        if (existingTable != null && existingTable.Id != request.TableId)
        {
            throw new ValidationException($"Table code '{request.Code}' already exists.");
        }
        
        table.UpdateCode(request.Code);

        _unitOfWork.Tables.Update(table);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}