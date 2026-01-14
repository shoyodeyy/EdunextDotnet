

using Edunext.Application.Abstractions.Persistence;
using Edunext.Application.DTOs.MenuCategory;
using MediatR;

namespace Edunext.Application.Features.MenuCategory.Queries;

public class GetAllMenuCategoryHandler 
    : IRequestHandler<GetAllMenuCategoryQuery, List<MenuCategoryDto>>
{
    private readonly IMenuCategoryRepository _categoryRepository;

    public GetAllMenuCategoryHandler(IMenuCategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository; 
    }

    public async Task<List<MenuCategoryDto>> Handle(
        GetAllMenuCategoryQuery request, CancellationToken ct)
    {
        var categories = await _categoryRepository.GetAllActiveAsync();

        return categories.Select(c => new MenuCategoryDto
        {
            MenuCateId = c.Id,
            Name = c.Name,
        }).ToList();
    }
}
