using Edunext.Application.Abstractions.Persistence;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Edunext.Application.Features.Menu.Commands.UpdateMenuItem;

public class UpdateMenuItemHandler
    : IRequestHandler<UpdateMenuItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMenuItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork; 
    }
    public async Task Handle(UpdateMenuItemCommand request, CancellationToken ct)
    {
        if (request.MenuItemId == Guid.Empty)
        {
            throw new ValidationException("MenuId cannot be empty.");
        }

        var menuItem = await _unitOfWork.Menus.GetByIdAsync(request.MenuItemId, ct);

        if (menuItem == null)
        {
            throw new KeyNotFoundException("Menu item not found.");
        }

        if (request.Name is not null)
        {
            menuItem.UpdateName(request.Name);
        }

        if (request.Price.HasValue)
        {
            menuItem.UpdatePrice(request.Price.Value);
        }

        if (request.Quantity.HasValue)
        {
            menuItem.UpdateQuantity(request.Quantity.Value);
        }

        if (request.Description is not null)
        {
            menuItem.UpdateDescription(request.Description);
        }

        if (request.ImageUrl is not null)
        {
            menuItem.UpdateImageUrl(request.ImageUrl);
        }

        if (request.CategoryId.HasValue)
        {
            var category = await _unitOfWork.MenuCategories.GetByIdAsync(request.CategoryId.Value, ct);

            if (category == null)
            {
                throw new KeyNotFoundException("Menu category not found.");
            }

            if (!category.IsActive)
            {
                throw new ValidationException("Menu category is inactive.");
            }

            menuItem.UpdateCategory(request.CategoryId.Value);
        }

        _unitOfWork.Menus.Update(menuItem);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
