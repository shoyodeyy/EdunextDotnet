using Edunext.Application.Abstractions.Persistence;
using MediatR;

namespace Edunext.Application.Features.Tables.Commands.DisableTable;

public class DisableTableHandler : IRequestHandler<DisableTableCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DisableTableHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DisableTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWork.Tables.GetByIdAsync(request.TableId);

        if (table == null)
        {
            throw new KeyNotFoundException($"Table {request.TableId} not found");
        }

        table.Disable();

        _unitOfWork.Tables.Update(table);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}