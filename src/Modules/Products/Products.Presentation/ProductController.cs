using Breadboard.Application.ResultPattern;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.Queries;
using Products.Domain.Products.Viewmodels;
using SharedKernel.Presentation.Attributes;

namespace Products.Presentation;

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