using Edunext.Core.Entities;

namespace Edunext.Application.Abstractions.Persistence;

public interface ITableRepository
{
    Task<IEnumerable<Table>> GetAllAsync(bool? isActive = null);
    Task<Table?> GetByIdAsync(Guid tableId);
    Task<Table?> GetByCodeAsync(string code);
    Task AddAsync(Table table);
    void Update(Table table);
    void Delete(Table table);
}