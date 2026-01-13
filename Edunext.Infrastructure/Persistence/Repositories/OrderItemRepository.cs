using Edunext.Application.Abstractions.Persistence;
using Edunext.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edunext.Infrastructure.Persistence.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly AppDbContext _context;

    public OrderItemRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<OrderItem?> GetByIdAsync(Guid orderItemId)
    {
        return await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == orderItemId);
    }

    public async Task AddAsync(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
    }

    public void Update(OrderItem orderItem)
    {
        _context.OrderItems.Update(orderItem);
    }

    public void Delete(OrderItem orderItem)
    {
        _context.OrderItems.Remove(orderItem);
    }
}