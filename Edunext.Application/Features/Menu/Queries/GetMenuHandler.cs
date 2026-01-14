using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.DTOs.Menu;
using Edunext.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.Features.Menu.Queries;

public class GetMenuHandler : IRequestHandler<GetMenuQuery, List<MenuItemDto>>
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
        var items = request.CategoryId.HasValue
            ? await _menuRepository.GetByCategoryIdAsync(request.CategoryId.Value)
            : await _menuRepository.GetAllAvailableAsync();
        
        return items.Select(x => new MenuItemDto
        {
            MenuId = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            ImageUrl = x.ImageUrl,
            Quantity = x.Quantity,
            IsAvailable = x.IsAvailable,
            CategoryName = x.Category.Name,
        }).ToList();
    }
}
