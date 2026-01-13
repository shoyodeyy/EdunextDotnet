using Edunext.Application.Abstractions.Persistence;
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
            throw new ArgumentException("TableId cannot be empty", nameof(request.TableId));
        }
        
        var table = await _unitOfWork.Tables.GetByIdAsync(request.TableId);
        if (table == null)
        {
            throw new KeyNotFoundException($"Table with ID {request.TableId} not found");
        }

        if (!table.IsActive)
        {
            throw new InvalidOperationException("Cannot create order for inactive table");
        }

        var order = new Order(request.TableId);

        await _unitOfWork.Orders.AddAsync(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}