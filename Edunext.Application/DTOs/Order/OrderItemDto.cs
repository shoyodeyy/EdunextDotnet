namespace Edunext.Application.DTOs.Order;

public class OrderItemDto
{
    public Guid MenuItemId { get; set; }
    public string MenuItemName { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;
}