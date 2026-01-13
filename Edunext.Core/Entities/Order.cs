using Edunext.Core.Common;
using Edunext.Core.Enums;

namespace Edunext.Core.Entities;

public class Order : BaseEntity
{
    public Guid TableId { get; private set; }
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public DateTime CreateAt { get; private set; } = DateTime.UtcNow;

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public decimal TotalPrice => _items.Sum(x => x.TotalPrice);

    private Order()
    {
    }

    public Order(Guid tableId)
    {
        TableId = tableId;
    }

    public void AddItem(OrderItem item)
    {
        if (item.OrderId != Id)
        {
            throw new InvalidOperationException("OrderItem does not belong to this Order");
        }
        _items.Add(item);
    }

    public void RemoveItem(Guid orderItemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == orderItemId);
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public void Submit()
    {
        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException("Cannot submit a pending order.");
        } 
        
        Status = OrderStatus.Cooking;
    }

    public void Complete()
    {
        Status = OrderStatus.Done;
    }

    public void MarkPaid()
    {
        Status = OrderStatus.Paid;
    }
}