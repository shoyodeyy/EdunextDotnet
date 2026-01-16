using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.DTOs.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.Features.Menu.Queries.GetAllMenu
{
    public class GetAllMenuHandler : IRequestHandler<GetAllMenuQuery, List<MenuItemDto>>
    {
        private readonly IMenuRepository _menuRepository;

        public GetAllMenuHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<List<MenuItemDto>> Handle(GetAllMenuQuery request, CancellationToken cancellationToken)
        {
            var items = await _menuRepository.GetAllAvailableAsync();

            return items.Select(x => new MenuItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Quantity = x.Quantity,
                IsAvailable = x.IsAvailable,
                CategoryName = x.Category.Name
            }).ToList();
        }
    }
}
