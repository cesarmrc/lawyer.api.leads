using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.Example.Create;
using lawyer.api.leads.application.UseCases.Example.Delete;
using lawyer.api.leads.application.UseCases.Example.GetAll;
using lawyer.api.leads.application.UseCases.Example.GetById;
using lawyer.api.leads.application.UseCases.Example.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lawyer.api.leads.webapi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExampleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExampleDto>>> Get()
    {
        var entities = await _mediator.Send(new GetAllExampleQuery());
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExampleDto>> Get(Guid id)
    {
        var entity = await _mediator.Send(new GetByIdExampleQuery(id));
        return Ok(entity);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post([FromBody] CreateExampleCommand command)
    {
        var id = await _mediator.Send(command);
        var url = Url.Action(nameof(Get), new { id });
        return Created(url, id);
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Put([FromBody] UpdateExampleCommand command)
    {
        if (command.Id == Guid.Empty)
            return BadRequest("The provided ID is not valid.");

        var updatedId = await _mediator.Send(command);
        return Ok(updatedId);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteExampleCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
