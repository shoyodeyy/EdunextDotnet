using Edunext.Application.Abstractions.Persistence;
using Edunext.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Edunext.Application.Features.Menu.Commands.CreateMenuItem;

public class CreateMenuItemHandler : IRequestHandler<CreateMenuItemCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMenuItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork; 
    }

    public async Task<Guid> Handle(CreateMenuItemCommand request, CancellationToken ct)
    {
        if (request.CategoryId == Guid.Empty)
        {
            throw new ValidationException("CategoryId cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ValidationException("Menu item cannot be empty.");
        }

        if (request.Price <= 0)
        {
            throw new ValidationException("Price must be greater than 0");
        }

        if (request.Quantity < 0)
        {
            throw new ValidationException("Quantity cannot be negative.");
        }

        var category = await _unitOfWork.MenuCategories.GetByIdAsync(request.CategoryId, ct);

        if (category == null)
        {
            throw new KeyNotFoundException("Menu category not found!");
        }

        if (!category.IsActive)
        {
            throw new ValidationException("Menu category is inactive.");
        }

        var menuItem = new MenuItem(
            request.CategoryId,
            request.Name,
            request.Price,
            request.Quantity,
            request.Description,
            request.ImageUrl
        );

        await _unitOfWork.Menus.AddAsync(menuItem, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return menuItem.Id;
    }
}
