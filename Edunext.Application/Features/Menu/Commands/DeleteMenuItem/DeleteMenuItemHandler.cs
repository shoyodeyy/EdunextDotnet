using Edunext.Application.Abstractions.Persistence;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Edunext.Application.Features.Menu.Commands.DeleteMenuItem;

public class DeleteMenuItemHandler : IRequestHandler<DeleteMenuItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMenuItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteMenuItemCommand request, CancellationToken ct)
    {
        if (request.MenuItemId == Guid.Empty)
        {
            throw new ValidationException("MenuItemId is required.");
        }

        var menuItem = await _unitOfWork.Menus.GetByIdAsync(request.MenuItemId, ct);

        if (menuItem == null)
        {
            throw new KeyNotFoundException("Menu item not found");
        }

        var hasActiveOrders = await _unitOfWork.Menus.HasActiveOrdersAsync(request.MenuItemId, ct);

        if (hasActiveOrders)
        {
            throw new ValidationException("Cannot delete menu item. Its being used in active orders (Pending, Cooking, Done).");

        }

        _unitOfWork.Menus.Delete(menuItem);
        
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
