using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.DTOs.Menu;
using MediatR;

namespace Edunext.Application.Features.Menu.Queries.GetMenuDetail;

internal class GetMenuDetailHandler
    : IRequestHandler<GetMenuDetailQuery, MenuItemDto?>
{
    private readonly IMenuRepository _menuRepository;

    public GetMenuDetailHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<MenuItemDto?> Handle(
        GetMenuDetailQuery request,
        CancellationToken ct)
    {
        var menu = await _menuRepository.GetByIdAsync(request.MenuId);

        if (menu == null)
            return null;

        if (!menu.Category.IsActive)
            return null;

        return new MenuItemDto
        {
            MenuId = menu.Id,
            Name = menu.Name,
            Description = menu.Description,
            Price = menu.Price,
            ImageUrl = menu.ImageUrl,
            Quantity = menu.Quantity,
            IsAvailable = menu.IsAvailable,
            CategoryName = menu.Category.Name
        };
    }
}
