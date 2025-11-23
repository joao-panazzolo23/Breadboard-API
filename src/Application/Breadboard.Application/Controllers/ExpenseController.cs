using Breadboard.Application.Attributes;
using Breadboard.Shared.Cops;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[DynamicVersion]
public class ExpenseController(ICops dispatcher) : ControllerBase
{
    private readonly ICops _dispatcher = dispatcher;
    
    [HttpPost]
    public IActionResult Add()
    {
        // _bridge.Send<>()
        throw new NotImplementedException();
        //todo: if expense category is not registered, create one half-populated
    }
}