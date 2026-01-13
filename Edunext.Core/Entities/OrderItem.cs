using Edunext.Core.Common;

namespace Edunext.Core.Entities;

public class OrderItem : BaseEntity
{
    public Guid MenuItemId { get; private set; }
    public string MenuItemName { get; private set; } = default!;
    public decimal UnitPrice { get; private set; }

    public int Quantity { get; private set; }
    public string? Note { get; private set; }

    public decimal TotalPrice => UnitPrice * Quantity;

    private OrderItem()
    {
    }

    public OrderItem(Guid menuItemId, string name, decimal price, int quantity, string? note)
    {
        MenuItemId = menuItemId;
        MenuItemName = name;
        UnitPrice = price;
        Quantity = quantity;
        Note = note;
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}