namespace Edunext.Application.Abstractions.Persistence;

public interface IUnitOfWork : IDisposable
{
    ITableRepository Tables { get; }
    IMenuRepository Menus { get; }
    IOrderRepository Orders { get; }
    
    // trả về số bản bị ảnh hưởng
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}