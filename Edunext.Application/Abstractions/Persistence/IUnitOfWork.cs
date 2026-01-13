namespace Edunext.Application.Abstractions.Persistence;

public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }
    IMenuRepository Menus { get; }
    
}