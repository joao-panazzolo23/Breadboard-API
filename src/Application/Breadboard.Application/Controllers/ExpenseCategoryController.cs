using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class ExpenseCategoryController
{
    public ExpenseCategoryController()
    {
        
    }

    [HttpPost]
    public IActionResult Add()
    {
        //todo: creating expense category handler
        throw new NotImplementedException();
    }
    
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