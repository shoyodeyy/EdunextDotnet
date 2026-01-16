using Edunext.Application.DTOs.Menu;
using MediatR;

namespace Edunext.Application.Features.Menu.Queries.GetAllMenu;

public record GetAllMenuQuery() : IRequest<List<MenuItemDto>>;