using Edunext.Application.Abstractions.Persistence;
using Edunext.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edunext.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _context;

    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MenuItem?> GetByIdAsync(Guid menuId, CancellationToken ct = default)
    {
        return await _context.MenuItems
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == menuId, ct);
    }

    public async Task AddAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
    }

    public async Task<IEnumerable<MenuItem>> GetAllAvailableAsync(CancellationToken ct = default)
    {
        return await _context.MenuItems
            .Include(x => x.Category)
            .Where(x =>
                x.Quantity > 0 &&
                x.Category.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(Guid categoryId, CancellationToken ct = default)
    {
        return await _context.MenuItems
            .Include(x => x.Category)
            .Where(x =>
                x.CategoryId == categoryId &&
                x.Quantity > 0 &&
                x.Category.IsActive)
            .ToListAsync();
    }

    public async Task AddAsync(MenuItem menuItem, CancellationToken ct = default)
    {
        await _context.MenuItems.AddAsync(menuItem, ct);
    }


    public void Update(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
    }

    public async Task<bool> HasActiveOrdersAsync(Guid menuItemId, CancellationToken ct = default)
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)
            .AnyAsync(oi => oi.MenuItemId == menuItemId
                            && oi.Order.Status != Core.Enums.OrderStatus.Paid, ct);
                
    }

    public void Delete(MenuItem menuItem)
    {
        _context.MenuItems.Remove(menuItem);
    }
}
