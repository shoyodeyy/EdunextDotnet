using Edunext.Application.Abstractions.Persistence;
using Edunext.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Edunext.Infrastructure.Persistence.Repositories;

public class MenuCategoryRepository : IMenuCategoryRepository
{
    private readonly AppDbContext _context;

    public MenuCategoryRepository(AppDbContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<MenuCategory>> GetAllActiveAsync()
    {
        return await _context.MenuCategories
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }
}
