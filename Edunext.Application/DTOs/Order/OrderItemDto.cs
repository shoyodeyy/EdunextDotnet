namespace Edunext.Application.DTOs.Order;

public class OrderItemDto
{
    public Guid OrderItemId { get; set; }
    public Guid MenuItemId { get; set; }
    public string Name { get; set; } = default!;
    public string MenuItemName { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Note { get; set; }
}