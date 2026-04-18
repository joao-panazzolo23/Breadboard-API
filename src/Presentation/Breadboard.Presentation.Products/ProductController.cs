using Breadboard.Application.Products.Queries;
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Products.Viewmodels;
using Breadboard.Presentation.Attributes;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.Products;

[ApiController]
[AutoRouting]
public class ProductController(
    IMediator mediator
) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Result<IEnumerable<ListProductDto>>>> Login([FromQuery] ListProductsQuery command)
    {
        var response = await mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }
}