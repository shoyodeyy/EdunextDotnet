using Edunext.Core.Entities;

namespace Edunext.Application.Abstractions.Persistence;

public interface IMenuCategoryRepository
{
    Task<IEnumerable<MenuCategory>> GetAllActiveAsync();
}
