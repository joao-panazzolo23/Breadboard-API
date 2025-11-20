using Breadboard.Shared.LightBridge;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[Route("api/v1/[controller]")]
public class ExpenseController(ILightDispatcher dispatcher) : ControllerBase
{
    private readonly ILightDispatcher _dispatcher = dispatcher;
    
    [HttpPost]
    public IActionResult Add()
    {
        // _bridge.Send<>()
        throw new NotImplementedException();
        //todo: if expense category is not registered, create one half-populated
    }
}