namespace Edunext.Application.DTOs.Menu;

public class MenuItemDto
{
    public Guid MenuId { get; set; }
    public string Name { get; set; } = default!;
    public string?  Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public int Quantity { get; set; }
    public bool IsAvailable { get; set; }
    public string CategoryName { get; set; } = default!;
}