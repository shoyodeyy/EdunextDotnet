using MediatR;

namespace Edunext.Application.Features.Menu.Commands.DeleteMenuItem;

public record DeleteMenuItemCommand(Guid MenuItemId) : IRequest;
