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

    public async Task<MenuItem?> GetByIdAsync(Guid menuId)
    {
        return await _context.MenuItems
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == menuId);
    }

    public async Task AddAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
    }

    public async Task<IEnumerable<MenuItem>> GetAllAvailableAsync()
    {
        return await _context.MenuItems
            .Include(x => x.Category)
            .Where(x =>
                x.Quantity > 0 &&
                x.Category.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(Guid categoryId)
    {
        return await _context.MenuItems
            .Include(x => x.Category)
            .Where(x =>
                x.CategoryId == categoryId &&
                x.Quantity > 0 &&
                x.Category.IsActive)
            .ToListAsync();
    }


    public void Update(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
    }
}
