using Edunext.Application.DTOs.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.Features.Menu.Queries.GetMenuDetail;

public record GetMenuDetailQuery(Guid MenuId) : IRequest<MenuItemDto?>;
