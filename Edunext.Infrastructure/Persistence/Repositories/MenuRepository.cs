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
            .FirstOrDefaultAsync(m => m.Id == menuId);
    }

    public async Task<MenuItem?> GetByCodeAsync(string code)
    {
        return await _context.MenuItems
            .FirstOrDefaultAsync(m => m.Name == code);
    }

    public async Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(Guid categoryId)
    {
        return await _context.MenuItems.Where(m => m.CategoryId == categoryId && m.IsAvailable).ToListAsync();
    }

    public async Task AddAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
    }

    public void Update(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
    }
}