namespace Edunext.Application.DTOs.Order;

public class OrderDto
{
    public Guid OrderId { get; set; }
    public Guid TableId { get; set; }
    public string Status { get; set; } = default!;
    public decimal TotalPrice { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}