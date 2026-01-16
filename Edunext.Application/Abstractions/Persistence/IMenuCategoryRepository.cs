using Edunext.Core.Entities;

namespace Edunext.Application.Abstractions.Persistence;

public interface IMenuCategoryRepository
{
    Task<MenuCategory?> GetByIdAsync(
        Guid id,
        CancellationToken ct = default);

    Task<IEnumerable<MenuCategory>> GetAllActiveAsync(
        CancellationToken ct = default);
}
