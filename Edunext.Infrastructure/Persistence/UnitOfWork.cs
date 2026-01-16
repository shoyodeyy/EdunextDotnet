using Edunext.Application.Abstractions.Persistence;
using Edunext.Infrastructure.Persistence.Repositories;

namespace Edunext.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private ITableRepository? _tableRepository;
    private IMenuRepository? _menuRepository;
    private IOrderRepository? _orderRepository;
    private IOrderItemRepository? _orderItemRepository;
    private IMenuCategoryRepository? _menuCategoryRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ITableRepository Tables => _tableRepository ??= new TableRepository(_context);
    public IMenuRepository Menus => _menuRepository ??= new MenuRepository(_context);
    public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);
    public IOrderItemRepository OrderItems => _orderItemRepository ??= new OrderItemRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public IMenuCategoryRepository MenuCategories
        => _menuCategoryRepository ??= new MenuCategoryRepository(_context);
}   