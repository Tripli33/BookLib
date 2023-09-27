using Application.Customer.Commands;
using Application.Customer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Customer;

namespace BookLib.Presentation.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(customers.OrderBy(customer => customer.CustomerId));
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody] CustomerForAddDto customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        _mediator.Send(new AddCustomerCommand(customer));
        return Ok();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetCustomer(long id)
    {
        var customer = await _mediator.Send(new GetCustomerQuery(id));
        return Ok(customer);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(long id)
    {
        await _mediator.Send(new DeleteCustomerCommand(id));
        return Ok();
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(long id, [FromBody] CustomerForUpdateDto customer)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        await _mediator.Send(new UpdateCustomerCommand(id, customer));
        return Ok();
    }
}