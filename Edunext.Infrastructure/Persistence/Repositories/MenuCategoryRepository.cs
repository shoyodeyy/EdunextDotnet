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

    public async Task<IEnumerable<MenuCategory>> GetAllActiveAsync(CancellationToken ct = default)
    {
        return await _context.MenuCategories
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .ToListAsync(ct);
    }

    public async Task<MenuCategory?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.MenuCategories.FirstOrDefaultAsync(c => c.Id == id, ct);
    }
}
