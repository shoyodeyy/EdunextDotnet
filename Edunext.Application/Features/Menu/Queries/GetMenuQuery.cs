using Edunext.Application.DTOs.Menu;
using MediatR;

namespace Edunext.Application.Features.Menu.Queries;

public record GetMenuQuery(Guid? CategoryId) : IRequest<List<MenuItemDto>>;

