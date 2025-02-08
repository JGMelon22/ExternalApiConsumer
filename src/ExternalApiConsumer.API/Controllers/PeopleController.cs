using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExternalApiConsumer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IManagePersonService _managePersonService;

    public PeopleController(IManagePersonService managePersonService)
    {
        _managePersonService = managePersonService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllOrdersAsync()
    {
        ServiceResponse<IEnumerable<Person>> people = await _managePersonService.GetPeopleAsync();
        return people.Data != null && people.Data.Any()
            ? Ok(people)
            : NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPersonAsync([FromRoute] int id)
    {
        ServiceResponse<Person> person = await _managePersonService.GetPersonAsync(id);
        return person.Data != null
            ? Ok(person)
            : NotFound(person);
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePersonAsync([FromBody] Person newPerson)
    {
        ServiceResponse<bool> person = await _managePersonService.CreatePersonAsync(newPerson);
        return person.Success != false
            ? NoContent()
            : BadRequest(person);
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeletePeopleAsync()
    {
        ServiceResponse<bool> person = await _managePersonService.DeletePeopleAsync();
        return person.Success != false
            ? NoContent()
            : BadRequest(person);
    }
}
