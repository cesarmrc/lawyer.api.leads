using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.Country.Create;
using lawyer.api.leads.application.UseCases.Country.Delete;
using lawyer.api.leads.application.UseCases.Country.GetAll;
using lawyer.api.leads.application.UseCases.Country.GetById;
using lawyer.api.leads.application.UseCases.Country.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lawyer.api.leads.webapi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CountryQueryDto>>> Get()
    {
        var entities = await _mediator.Send(new GetAllCountryQuery());
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CountryQueryDto>> Get(Guid id)
    {
        var entity = await _mediator.Send(new GetByIdCountryQuery(id));
        return Ok(entity);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post([FromBody] CreateCountryCommand command)
    {
        var id = await _mediator.Send(command);
        var url = Url.Action(nameof(Get), new { id });
        return Created(url, id);
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Put([FromBody] UpdateCountryCommand command)
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
        var command = new DeleteCountryCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
