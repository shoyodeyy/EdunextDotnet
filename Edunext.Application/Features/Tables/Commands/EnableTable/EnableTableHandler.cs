using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
using MediatR;

namespace Edunext.Application.Features.Tables.Commands.EnableTable;

public class EnableTableHandler : IRequestHandler<EnableTableCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public EnableTableHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EnableTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWork.Tables.GetByIdAsync(request.TableId);
        if (table == null)
        {
            throw new NotFoundException($"Table {request.TableId} not found");
        }

        table.Enable();

        _unitOfWork.Tables.Update(table);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}