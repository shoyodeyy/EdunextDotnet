using Edunext.Application.DTOs.Table;
using Edunext.Application.Features.Tables.Commands;
using Edunext.Application.Features.Tables.Commands.CreateTable;
using Edunext.Application.Features.Tables.Commands.DisableTable;
using Edunext.Application.Features.Tables.Commands.EnableTable;
using Edunext.Application.Features.Tables.Commands.UpdateTable;
using Edunext.Application.Features.Tables.Queries.GetAllTables;
using Edunext.Application.Features.Tables.Queries.GetTableById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edunext.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TablesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TablesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableDto>>> GetAll([FromQuery] bool? isActive = null)
    {
        var query = new GetAllTablesQuery(isActive);
        var tables = await _mediator.Send(query);
        return Ok(tables);
    }

    [HttpGet("{tableId}")]
    public async Task<ActionResult<TableDetailDto>> GetById(Guid tableId)
    {
        var query = new GetTableByIdQuery(tableId);
        var table = await _mediator.Send(query);

        if (table == null) return NotFound();

        return Ok(table);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateTableRequest createTableRequest)
    {
        var command = new CreateTableCommand(createTableRequest.Code);
        var tableId = await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{tableId}")]
    public async Task<ActionResult> Update(Guid tableId, [FromBody] UpdateTableRequest updateTableRequest)
    {
        var command = new UpdateTableCommand(tableId, updateTableRequest.Code);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPatch("{tableId}/disable")]
    public async Task<ActionResult> Disable(Guid tableId)
    {
        var command = new DisableTableCommand(tableId);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPatch("{tableId}/enable")]
    public async Task<ActionResult> Enable(Guid tableId)
    {
        var command = new EnableTableCommand(tableId);
        await _mediator.Send(command);
        return NoContent();
    }
}

public record CreateTableRequest(string Code);

public record UpdateTableRequest(string Code);