using Edunext.Application.Features.MenuCategory.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edunext.API.Controllers;


[ApiController]
[Route("api/menu-categories")]
public class MenuCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public MenuCategoryController(IMediator mediator)
    {
        _mediator = mediator; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMenuCategory()
    {
        var result = await _mediator.Send(new GetAllMenuCategoryQuery());
        return Ok(result);
    }
}
