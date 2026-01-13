using Edunext.Core.Entities;

namespace Edunext.Core.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<Order?> GetActiveByTableAsync(Guid tableId);
    Task AddAsync(Order order);
    void Update(Order order);
}