using Edunext.Application.Features.Orders.Commands.AddItemToOrder;
using Edunext.Application.Features.Orders.Commands.CompleteOrder;
using Edunext.Application.Features.Orders.Commands.CreateOrder;
using Edunext.Application.Features.Orders.Commands.SubmitOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edunext.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrder), new { id = orderId }, orderId);
    }

    [HttpPost("{orderId}/items")]
    public async Task<ActionResult> AddItem(Guid orderId, [FromBody] AddItemRequest request)
    {
        var command = new AddItemToOrderCommand(
            orderId,
            request.MenuItemId,
            request.Quantity,
            request.Note
        );

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{orderId}/submit")]
    public async Task<ActionResult> Submit(Guid orderId)
    {
        await _mediator.Send(new SubmitOrderCommand(orderId));
        return NoContent();
    }

    [HttpPost("{orderId}/complete")]
    public async Task<ActionResult> Complete(Guid orderId)
    {
        await _mediator.Send(new CompleteOrderCommand(orderId));
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOrder(Guid id)
    {
        // TODO: Implement Query
        return Ok();
    }
}

public record AddItemRequest(Guid MenuItemId, int Quantity, string? Note);