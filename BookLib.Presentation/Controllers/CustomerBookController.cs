using Application.Author.Commands;
using Application.CustomerBook.Commands;
using Application.CustomerBook.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.CustomerBook;

namespace BookLib.Presentation.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerBookController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerBookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("{customerId}/books")]
    [HttpGet]
    public async Task<IActionResult> GetAllCustomerBooks(long customerId)
    {
        var books = await _mediator.Send(new GetAllCustomerBooksQuery(customerId));
        return Ok(books);
    }

    [Route("{customerId}/books")]
    [HttpPost]
    public async Task<IActionResult> AddCustomerBook(long customerId, CustomerBookDto book)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        await _mediator.Send(new AddCustomerBookCommand(customerId, book));
        return Ok();
    }

    [Route("{customerId}/books/{bookId}")]
    [HttpGet]
    public async Task<IActionResult> GetCustomerBook(long customerId, long bookId)
    {
        var book = await _mediator.Send(new GetCustomerBookQuery(customerId, bookId));
        return Ok(book);
    }

    [Route("{customerId}/books/{bookId}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomerBook(long customerId, long bookId)
    {
        await _mediator.Send(new DeleteCustomerBookCommand(customerId, bookId));
        return Ok();
    }    
}