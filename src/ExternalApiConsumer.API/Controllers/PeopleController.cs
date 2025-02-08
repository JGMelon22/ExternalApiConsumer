using ExternalApiConsumer.Application.People.Commands;
using ExternalApiConsumer.Application.People.Queries;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Requests;
using ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;
using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
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
    public async Task<IActionResult> GetAllOrdersAsync()
    {
        ServiceResponse<IEnumerable<PersonResponse>> people = await _mediator.Send(new GetPeopleQuery());
        return people.Data != null && people.Data.Any()
            ? Ok(people)
            : NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPersonAsync([FromRoute] int id)
    {
        ServiceResponse<PersonResponse> person = await _mediator.Send(new GetPersonByIdQuery(id));
        return person.Data != null
            ? Ok(person)
            : NotFound(person);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePersonAsync([FromBody] PersonRequest newPerson)
    {
        ServiceResponse<bool> person = await _mediator.Send(new CreatePersonCommand(newPerson));
        return person.Success != false
            ? NoContent()
            : BadRequest(person);
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeletePeopleAsync()
    {
        ServiceResponse<bool> person = await _mediator.Send(new DeletePersonCommand());
        return person.Success != false
            ? NoContent()
            : BadRequest(person);
    }
}
