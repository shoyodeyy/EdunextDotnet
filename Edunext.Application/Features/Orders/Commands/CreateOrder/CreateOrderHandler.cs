using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.Common.Exceptions;
using Edunext.Core.Entities;
using MediatR;

namespace Edunext.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.TableId == Guid.Empty)
        {
            throw new ValidationException("Table cannot be empty");
        }
        
        var table = await _unitOfWork.Tables.GetByIdAsync(request.TableId);
        if (table == null)
        {
            throw new NotFoundException($"Table {request.TableId} not found");
        }

        if (!table.IsActive)
        {
            throw new ValidationException("Table is disabled");
        }
        
        var activeOrder = await _unitOfWork.Orders.GetActiveByTableAsync(request.TableId);
        if (activeOrder != null)
        {
            throw new ValidationException("This table already has an active order");
        }

        var order = new Order(request.TableId);

        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}