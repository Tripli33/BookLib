using Application.Book.Commands;
using Application.Book.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Book;

namespace BookLib.Presentation.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _mediator.Send(new GetAllBooksQuery());
        return Ok(books.OrderBy(book => book.BookId));
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] ExtendBookForAddDto book)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        await _mediator.Send(new AddBookCommand(book));
        return Ok();
    }

    [Route("names/{name}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByName(string name)
    {
        var books = await _mediator.Send(new GetAllBooksByNameQuery(name));
        return Ok(books);
    }

    [Route("genres/{genreName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByGenre(string genreName)
    {
        var books = await _mediator.Send(new GetAllBooksByGenreQuery(genreName));
        return Ok(books);
    }

    [Route("languages/{languageName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByLanguage(string languageName)
    {
        var books = await _mediator.Send(new GetAllBooksByLanguageQuery(languageName));
        return Ok(books);
    }

    [Route("authors/{authorName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByAuthor(string authorName)
    {
        var books = await _mediator.Send(new GetAllBooksByAuthorQuery(authorName));
        return Ok(books);
    }

    [Route("publishers/{publisherName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByPublisher(string publisherName)
    {
        var books = await _mediator.Send(new GetAllBooksByPublishQuery(publisherName));
        return Ok(books);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetBook(long id)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id));
        return Ok(book);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteBook(long id)
    {
        await _mediator.Send(new DeleteBookCommand(id));
        return Ok();
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdateBook(long id, [FromBody] ExtendBookForUpdateDto book)
    {
        await _mediator.Send(new UpdateBookCommand(id, book));
        return Ok();
    }

    
}