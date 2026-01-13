using Edunext.Core.Entities;

namespace Edunext.Application.Abstractions.Persistence;

public interface IMenuRepository
{
    Task<MenuItem?> GetByIdAsync(Guid menuId);
    Task<MenuItem?> GetByCodeAsync(string code);
    Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(Guid categoryId);
    Task AddAsync(MenuItem menuItem);
    void Update(MenuItem menuItem);
}