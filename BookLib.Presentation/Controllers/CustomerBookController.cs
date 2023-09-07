using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace BookLib.Presentation.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerBookController : ControllerBase
{
    private readonly IServiceManager _manager;
    public CustomerBookController(IServiceManager manager)
    {
        _manager = manager;
    }

    [Route("{customerId}/books")]
    [HttpGet]
    public async Task<IActionResult> GetAllCustomerBooks(long customerId)
    {
        var books = await _manager.CustomerBookService.GetAllCustomerBooks(customerId);
        return Ok(books);
    }

    [Route("{customerId}/books")]
    [HttpPost]
    public async Task<IActionResult> AddCustomerBook(long customerId, CustomerBookDto book)
    {
        await _manager.CustomerBookService.AddCustomerBook(customerId, book);
        return Ok();
    }

    [Route("{customerId}/books/{bookId}")]
    [HttpGet]
    public async Task<IActionResult> GetCustomerBook(long customerId, long bookId)
    {
        var book = await _manager.CustomerBookService.GetCustomerBook(customerId, bookId);
        return Ok(book);
    }

    [Route("{customerId}/books/{bookId}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomerBook(long customerId, long bookId)
    {
        await _manager.CustomerBookService.DeleteCustomerBook(customerId, bookId);
        return Ok();
    }    
}