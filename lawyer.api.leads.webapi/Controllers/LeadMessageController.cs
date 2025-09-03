using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.LeadMessage.Create;
using lawyer.api.leads.application.UseCases.LeadMessage.Delete;
using lawyer.api.leads.application.UseCases.LeadMessage.GetAll;
using lawyer.api.leads.application.UseCases.LeadMessage.GetById;
using lawyer.api.leads.application.UseCases.LeadMessage.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lawyer.api.leads.webapi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LeadMessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeadMessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeadMessageDto>>> Get()
    {
        var entities = await _mediator.Send(new GetAllLeadMessageQuery());
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeadMessageDto>> Get(Guid id)
    {
        var entity = await _mediator.Send(new GetByIdLeadMessageQuery(id));
        return Ok(entity);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post([FromBody] CreateLeadMessageCommand command)
    {
        var id = await _mediator.Send(command);
        var url = Url.Action(nameof(Get), new { id });
        return Created(url, id);
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Put([FromBody] UpdateLeadMessageCommand command)
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
        var command = new DeleteLeadMessageCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

