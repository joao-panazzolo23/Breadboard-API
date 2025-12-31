using Breadboard.Application.Cops;
using Breadboard.Presentation.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.Controllers;

[ApiController]
[Authorize]
[AutoRouting]
public class ExpenseCategoryController(ICops cops)
{
    private readonly ICops _cops = cops;

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Get([FromRoute] Guid id)
    {
        //todo: bring just one expense category by ID, with all expenses, filtered data
        throw new NotImplementedException();
    }

    [HttpGet]
    public IActionResult List()
    {
        //todo: list all expenses, filtered
        throw new NotImplementedException();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut]
    public IActionResult Update()
    {
        //todo: list all expenses, filtered
        throw new NotImplementedException();
    }
}