using MediatR;

namespace Edunext.Application.Features.Menu.Commands.CreateMenuItem;

public record CreateMenuItemCommand(
    Guid CategoryId,
    string Name,
    decimal Price,
    int Quantity,
    string? Description,
    string? ImageUrl
    ) : IRequest<Guid>;