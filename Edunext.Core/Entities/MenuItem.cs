using Edunext.Core.Common;

namespace Edunext.Core.Entities;

public class MenuItem : BaseEntity
{
    public Guid CategoryId { get; private set;  }
    public MenuCategory Category { get; private set; } = default!;

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public string? ImageUrl { get; private set; }
    public int Quantity { get; private set; }

    public bool IsAvailable => Quantity > 0;

    private MenuItem() { }

    public MenuItem(
        Guid categoryId,
        string name,
        decimal price,
        int quantity)
    {
        CategoryId = categoryId;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void UpdatePrice(decimal price)
    {
        Price = price; 
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity; 
    }

    public void DecreaseQuantity(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Quantity must be greater than 0");
        }

        if (Quantity < amount)
        {
            throw new InvalidOperationException("Not enough quantity");
        }

        Quantity -= amount;
    }
}