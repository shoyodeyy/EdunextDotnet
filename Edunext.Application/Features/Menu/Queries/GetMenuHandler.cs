using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.DTOs.Menu;
using MediatR;

namespace Edunext.Application.Features.Menu.Queries;

public class GetMenuHandler
    : IRequestHandler<GetMenuQuery, List<MenuItemDto>>
{
    private readonly IMenuRepository _menuRepository;

    public GetMenuHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<List<MenuItemDto>> Handle(
        GetMenuQuery request,
        CancellationToken ct)
    {
        var menus = request.CategoryId.HasValue
            ? await _menuRepository.GetByCategoryIdAsync(request.CategoryId.Value)
            : await _menuRepository.GetAllAvailableAsync();

        return menus.Select(menu => new MenuItemDto
        {
            Id = menu.Id,
            Name = menu.Name,
            Description = menu.Description,
            Price = menu.Price,
            ImageUrl = menu.ImageUrl,
            Quantity = menu.Quantity,
            IsAvailable = menu.IsAvailable,
            CategoryName = menu.Category.Name
        }).ToList();
    }
}
