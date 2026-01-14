using Edunext.Application.Features.Menu.Queries;
using Edunext.Application.Features.Menu.Queries.GetMenuDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edunext.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController :ControllerBase
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator; 
    }

    [HttpGet]
    public async Task<IActionResult> GetMenu(
        [FromQuery] Guid? categoryId)
    {
        var result = await _mediator.Send(
            new GetMenuQuery(categoryId));
        return Ok(result);
    }

    [HttpGet("{menuId:guid}")]
    public async Task<IActionResult> GetMenuDetail(Guid menuId)
    {
        var result = await _mediator.Send(
            new GetMenuDetailQuery(menuId));

        if (result == null) return NotFound();

        return Ok(result);
    }
}