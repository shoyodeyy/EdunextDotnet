namespace Edunext.Application.DTOs.Menu;

public class MenuItemWithOrdersDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsAvailable { get; set; }
    public string CategoryName { get; set; } = default!;
    
    // Navigation property showing which orders contain this menu item
    public List<OrderSummaryForMenuDto> OrdersContainingThisItem { get; set; } = new();
    
    // Statistics
    public int TotalOrdersCount { get; set; }
    public int TotalQuantitySold { get; set; }
    public decimal TotalRevenueGenerated { get; set; }
}

public class OrderSummaryForMenuDto
{
    public Guid OrderId { get; set; }
    public Guid TableId { get; set; }
    public string TableCode { get; set; } = default!;
    public string OrderStatus { get; set; } = default!;
    public DateTime OrderDate { get; set; }
    public int QuantityOrdered { get; set; }
    public decimal RevenueFromThisItem { get; set; }
}