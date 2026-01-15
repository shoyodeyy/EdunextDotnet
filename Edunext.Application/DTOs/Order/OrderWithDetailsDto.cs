namespace Edunext.Application.DTOs.Order;

public class OrderWithDetailsDto
{
    public Guid Id { get; set; }
    public Guid TableId { get; set; }
    public string TableCode { get; set; } = default!;
    public string Status { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    
    // Order items with full menu item details
    public List<OrderItemWithMenuDto> Items { get; set; } = new();
    
    // Calculated properties
    public int TotalItems => Items.Sum(x => x.Quantity);
    public decimal SubTotal => Items.Sum(x => x.TotalPrice);
    public decimal Tax { get; set; }
    public decimal TotalPrice => SubTotal + Tax;
}

public class OrderItemWithMenuDto
{
    public Guid Id { get; set; }
    public Guid MenuItemId { get; set; }
    public string MenuItemName { get; set; } = default!;
    public string MenuItemDescription { get; set; } = default!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? Note { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;
    
    // Menu item category information
    public string CategoryName { get; set; } = default!;
    public bool IsAvailable { get; set; }
}