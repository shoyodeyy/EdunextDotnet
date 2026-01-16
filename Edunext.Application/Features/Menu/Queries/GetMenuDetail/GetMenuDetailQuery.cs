using Edunext.Application.DTOs.Menu;
using MediatR;

namespace Edunext.Application.Features.Menu.Queries.GetMenuDetail;

public record GetMenuDetailQuery(Guid MenuId) : IRequest<MenuItemDto?>;
