using ExternalApiConsumer.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExternalApiConsumer.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
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
        var orders = await _managePersonService.GetPeopleAsync();
        return orders.Data != null && orders.Data.Any()
            ? Ok(orders)
            : NoContent();
    }
}
