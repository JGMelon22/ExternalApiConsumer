using ExternalApiConsumer.Application.People.Commands;
using ExternalApiConsumer.Application.People.Queries;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExternalApiConsumer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IMediator _mediator;

    public PeopleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPeopleAsync()
    {
        var people = await _mediator.Send(new GetPeopleQuery());
        return people.Data != null && people.Data.Any()
            ? Ok(people)
            : NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPersonAsync([FromRoute] int id)
    {
        var person = await _mediator.Send(new GetPersonByIdQuery(id));
        return person.Data != null
            ? Ok(person)
            : NotFound(person);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePersonAsync([FromBody] PersonRequest newPerson)
    {
        var person = await _mediator.Send(new CreatePersonCommand(newPerson));
        return person.Success
            ? NoContent()
            : BadRequest(person);
    }

    [HttpPost("seed-data")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SeedDataAsync()
    {
        var seedData = await _mediator.Send(new SeedDataCommand());
        return seedData.Success
            ? NoContent()
            : BadRequest(seedData);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeletePeopleAsync()
    {
        var person = await _mediator.Send(new DeletePersonCommand());
        return person.Success
            ? NoContent()
            : BadRequest(person);
    }
}
