using Edunext.Application.DTOs.MenuCategory;
using MediatR;
using System;


namespace Edunext.Application.Features.MenuCategory.Queries;

public record GetAllMenuCategoryQuery() : IRequest<List<MenuCategoryDto>>;