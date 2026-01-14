using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
using Edunext.Core.Entities;
using MediatR;

namespace Edunext.Application.Features.Tables.Commands.CreateTable;

public class CreateTableHandler:IRequestHandler<CreateTableCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTableHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Code))
        {
            throw new ValidationException("Table code is required"); 
        }
        
        var existingTable = await _unitOfWork.Tables.GetByCodeAsync(request.Code);
        if (existingTable != null)
        {
            throw new ValidationException($"Table code '{request.Code}' already exists.");
        }

        var table = new Table(request.Code);
        
        await _unitOfWork.Tables.AddAsync(table);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return table.Id;
    }
}