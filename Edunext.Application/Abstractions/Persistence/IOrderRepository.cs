
using Edunext.Core.Entities;

namespace Edunext.Application.Abstractions.Persistence;


public interface IOrderRepository
{

    Task<Order?> GetActiveByTableAsync(Guid tableId);

    Task<Order?> GetByIdAsync(Guid orderId);

    Task AddAsync(Order order);
    void Update(Order order);
}