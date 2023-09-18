using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Book;

namespace BookLib.Presentation.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IServiceManager _manager;
    public BookController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _manager.BookService.GetAllBooks();
        return Ok(books.OrderBy(book => book.BookId));
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] ExtendBookForAddDto book)
    {
        await _manager.BookService.AddBook(book);
        return Ok();
    }

    [Route("names/{name}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByName(string name)
    {
        var books = await _manager.BookService.GetAllBooksByName(name);
        return Ok(books);
    }

    [Route("genres/{genreName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByGenre(string genreName)
    {
        var books = await _manager.BookService.GetAllBooksByGenre(genreName);
        return Ok(books);
    }

    [Route("languages/{languageName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByLanguage(string languageName)
    {
        var books = await _manager.BookService.GetAllBooksByLanguage(languageName);
        return Ok(books);
    }

    [Route("authors/{authorName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByAuthor(string authorName)
    {
        var books = await _manager.BookService.GetAllBooksByAuthor(authorName);
        return Ok(books);
    }

    [Route("publishers/{publisherName}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByPublisher(string publisherName)
    {
        var books = await _manager.BookService.GetAllBooksByPublisher(publisherName);
        return Ok(books);
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetBook(long id)
    {
        var book = await _manager.BookService.GetBook(id);
        return Ok(book);
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteBook(long id)
    {
        await _manager.BookService.DeleteBook(id);
        return Ok();
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdateBook(long id, [FromBody] ExtendBookForUpdateDto book)
    {
        await _manager.BookService.UpdateBook(id, book);
        return Ok();
    }

    
}