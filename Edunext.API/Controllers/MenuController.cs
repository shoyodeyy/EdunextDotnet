using Edunext.Application.DTOs.Menu;
using Edunext.Application.Features.Menu.Commands.CreateMenuItem;
using Edunext.Application.Features.Menu.Commands.DeleteMenuItem;
using Edunext.Application.Features.Menu.Commands.UpdateMenuItem;
using Edunext.Application.Features.Menu.Queries;
using Edunext.Application.Features.Menu.Queries.GetAllMenu;
using Edunext.Application.Features.Menu.Queries.GetMenuDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edunext.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator; 
    }

    //1. get all menu available (get: api/menu)
    [HttpGet]
    public async Task<IActionResult> GetAllMenu()
    {
        var result = await _mediator.Send(new GetAllMenuQuery());
        return Ok(result);
    }

    //2. Get menu by Category (Get: api/menu/by-category/{categoryId}
    [HttpGet("by-category/{categoryId:guid}")]
    public async Task<IActionResult> GetMenuByCategory(Guid categoryId)
    {
        var result = await _mediator.Send(new GetMenuQuery(categoryId));
        return Ok(result);
    }

    //3. GetMenuItemDetail (Get: api/menu/{menuId}
    [HttpGet("{menuId:guid}")]
    public async Task<IActionResult> GetMenuDetail(Guid menuId)
    {
        var result = await _mediator.Send(new GetMenuDetailQuery(menuId));

        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenuItem(
                                        [FromBody] CreateMenuItemRequest request)
    {
        var command = new CreateMenuItemCommand(
                request.CategoryId,
                request.Name,
                request.Price,
                request.Quantity,
                request.Description,
                request.ImageUrl
            );

        var menuItemId = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetMenuDetail),
            new { menuId = menuItemId },
            null);
    }

    [HttpPut("{menuId:guid}")]
    public async Task<IActionResult> UpdateMenuItem(Guid menuId,
                                                [FromBody] UpdateMenuItemRequest request)
    {
        var command = new UpdateMenuItemCommand(
            menuId,
            request.Name,
            request.Price,
            request.Quantity,
            request.Description,
            request.ImageUrl,
            request.CategoryId
            );
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete("{menuId:guid}")]
    public async Task<IActionResult> DeleteMenuItem(Guid MenuId)
    {
        await _mediator.Send(new DeleteMenuItemCommand(MenuId));
        return NoContent();
    }
}
