using MediatR;

namespace Edunext.Application.Features.Menu.Commands.UpdateMenuItem;

public record UpdateMenuItemCommand(
        Guid MenuItemId,
        string? Name,
        decimal? Price,
        int? Quantity,
        string? Description,
        string? ImageUrl,
        Guid? CategoryId
    ) : IRequest;
