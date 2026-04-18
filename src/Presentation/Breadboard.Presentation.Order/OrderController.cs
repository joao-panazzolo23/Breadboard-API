using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.Order;

public class OrderController(IMediator _mediator) : ControllerBase
{
    // [HttpPost("[action]")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // public async Task<ActionResult<Result<OrderDto>>> Login([FromBody] CreateOrderCommand command)
    // {
    //     var response = await _mediator.Send(command);
    //     return StatusCode(response.StatusCode, response);
    // }
}
//
//
// public class CreateOrderHandler : ControllerBase
// {
//     // [HttpPost("[action]")]
//     // [ProducesResponseType(StatusCodes.Status200OK)]
//     // [ProducesResponseType(StatusCodes.Status404NotFound)]
//     // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//     // public async Task<ActionResult<Result<OrderDto>>> Login([FromBody] CreateOrderCommand command)
//     // {
//     //     var response = await _mediator.Send(command);
//     //     return StatusCode(response.StatusCode, response);
//     // }
// }