using Breadboard.Domain.ExpensesCategory.Entities;
using Breadboard.Shared.LightBridge;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class ExpenseCategoryController
{
    public ILightDispatcher Dispatcher { get; set; }
    public ExpenseCategoryController(ILightDispatcher dispatcher)
    {
        Dispatcher = dispatcher;
    }

    // [HttpPost]
    // public Task<IActionResult> Add([FromBody]  expenseCategory)
    // {
    //     var response = _Bridge.Send<Nothing>();
    // }
    
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
    public IActionResult Update()
    {
        //todo: list all expenses, filtered
        throw new NotImplementedException();
    }


}