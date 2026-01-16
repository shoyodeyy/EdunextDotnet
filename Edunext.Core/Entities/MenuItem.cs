using System.ComponentModel.DataAnnotations;
using Edunext.Core.Common;

namespace Edunext.Core.Entities;

public class MenuItem : BaseEntity
{
    public Guid CategoryId { get; private set; }
    public MenuCategory Category { get; private set; } = default!;

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public decimal Price { get; private set; } = default!;
    public string? ImageUrl { get; private set; }
    public int Quantity { get; private set; }

    public bool IsAvailable => Quantity > 0;

    private MenuItem() { }

    public MenuItem(
        Guid categoryId,
        string name,
        decimal price,
        int quantity,
        string? description = null,
        string? imageUrl = null)
    {
        UpdateCategory(categoryId);
        UpdateName(name);
        UpdatePrice(price);
        UpdateQuantity(quantity);
        UpdateDescription(description);
        UpdateImageUrl(imageUrl);
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ValidationException("Menu item name connot be empty.");
        }

        Name = name.Trim();
    }

    public void UpdateDescription(string? description)
    {
        Description = description?.Trim();
    }

    public void UpdateImageUrl(string? imageUrl)
    {
        ImageUrl = imageUrl?.Trim();
    }

    public void UpdatePrice(decimal price)
    {
        if (price <= 0)
        {
            throw new ValidationException("Price must be greater than 0");
        }

        Price = price;
    }

    public void UpdateQuantity(int quantity)
    {
        if (quantity < 0)
        {
            throw new ValidationException("Quantity cannot be negative.");
        }
        Quantity = quantity;
    }

    public void UpdateCategory(Guid categoryId)
    {
        if (categoryId == Guid.Empty)
        {
            throw new ValidationException("CategoryId cannot be empty.");
        }

        CategoryId = categoryId;
    }

    public void DecreaseQuantity(int amount)
    {
        if (amount < 0)
        {
            throw new ValidationException("Amount must be greater than 0.");
        }

        if (Quantity < amount)
        {
            throw new ValidationException("Not enough quantity!");
        }

        Quantity -= amount;
    }
}