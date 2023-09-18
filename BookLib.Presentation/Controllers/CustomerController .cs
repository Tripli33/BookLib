using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Customer;

namespace BookLib.Presentation.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IServiceManager _manager;
    public CustomerController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _manager.CustomerService.GetAllCustomers();
        return Ok(customers.OrderBy(customer => customer.CustomerId));
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody] CustomerForAddDto customer)
    {
        _manager.CustomerService.AddCustomer(customer);
        return Ok();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetCustomer(long id)
    {
        var customer = await _manager.CustomerService.GetCustomer(id);
        return Ok(customer);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(long id)
    {
        await _manager.CustomerService.DeleteCustomer(id);
        return Ok();
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(long id, [FromBody] CustomerForUpdateDto customer)
    {
        await _manager.CustomerService.UpdateCustomer(id, customer);
        return Ok();
    }
}