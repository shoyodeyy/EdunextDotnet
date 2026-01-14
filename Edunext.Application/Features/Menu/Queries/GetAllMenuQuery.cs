using Edunext.Application.DTOs.Menu;
using MediatR;

namespace Edunext.Application.Features.Menu.Queries;

public record GetAllMenuQuery() : IRequest<List<MenuItemDto>>;


