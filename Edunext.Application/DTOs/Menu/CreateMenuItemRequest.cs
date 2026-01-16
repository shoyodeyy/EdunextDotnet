

namespace Edunext.Application.DTOs.Menu;

public record CreateMenuItemRequest (
    Guid CategoryId, string Name, decimal Price, int Quantity,
    string? Description, string? ImageUrl);