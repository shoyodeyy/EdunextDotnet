using Edunext.Application.Features.Menu.Queries;
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
    public async Task<IActionResult> GetMunu(
        [FromQuery] Guid? categoryId)
    {
        var result = await _mediator.Send(
            new GetMenuQuery(categoryId));
        return Ok(result);
    }
}