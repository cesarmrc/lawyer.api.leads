using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.Lead.Create;
using lawyer.api.leads.application.UseCases.Lead.Delete;
using lawyer.api.leads.application.UseCases.Lead.GetAll;
using lawyer.api.leads.application.UseCases.Lead.GetById;
using lawyer.api.leads.application.UseCases.Lead.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lawyer.api.leads.webapi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeadDto>>> Get()
    {
        var entities = await _mediator.Send(new GetAllLeadQuery());
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeadDto>> Get(Guid id)
    {
        var entity = await _mediator.Send(new GetByIdLeadQuery(id));
        return Ok(entity);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post([FromBody] CreateLeadCommand command)
    {
        var id = await _mediator.Send(command);
        var url = Url.Action(nameof(Get), new { id });
        return Created(url, id);
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Put([FromBody] UpdateLeadCommand command)
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
        var command = new DeleteLeadCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
