using Edunext.Core.Entities;

namespace Edunext.Application.Abstractions.Persistence;

public interface IMenuRepository
{
    Task<MenuItem?> GetByIdAsync(Guid menuId, CancellationToken ct = default);

    Task<IEnumerable<MenuItem>> GetAllAvailableAsync( CancellationToken ct = default);

    Task<IEnumerable<MenuItem>> GetByCategoryIdAsync( Guid categoryId, CancellationToken ct = default);

    Task AddAsync(MenuItem item, CancellationToken ct = default);

    Task<bool> HasActiveOrdersAsync(Guid menuItemId, CancellationToken ct = default);

    void Delete(MenuItem menuItem);

    void Update(MenuItem menuItem);
}