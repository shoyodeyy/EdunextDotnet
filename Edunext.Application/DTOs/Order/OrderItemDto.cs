namespace Edunext.Application.DTOs.Order;

public class OrderItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Note { get; set; }
}