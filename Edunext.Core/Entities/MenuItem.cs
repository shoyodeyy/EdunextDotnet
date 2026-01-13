using Edunext.Core.Common;

namespace Edunext.Core.Entities;

public class MenuItem : BaseEntity
{
    public Guid CategoryId { get; private set;  }
    public string Name { get; private set; } = default;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public string? ImageUrl { get; private set; }
    public bool IsAvailable { get; private set; } = true;

    private MenuItem() { }

    public MenuItem(Guid categoryId, string name, decimal price)
    {
        CategoryId = categoryId; 
        Name = name; 
        Price = price;
    }

    public void UpdatePrice(decimal price) {  Price = price; }

    public void MarkOutOfStock() { IsAvailable = false; }

    public void MarkAvaiable() { IsAvailable = true; }
}