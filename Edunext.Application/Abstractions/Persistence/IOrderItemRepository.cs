using Edunext.Core.Entities;

namespace Edunext.Application.Abstractions.Persistence;

public interface IOrderItemRepository
{
    Task<OrderItem?> GetByIdAsync(Guid orderItemId);
    Task AddAsync(OrderItem orderItem);
    void Update(OrderItem orderItem);
    void Delete(OrderItem orderItem);
}