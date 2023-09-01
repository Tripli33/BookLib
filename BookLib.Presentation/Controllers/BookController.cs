using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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
    public async Task<IActionResult> AddBook([FromBody] BookForAddDto book)
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

    [Route("genres/{genre}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByGenre(Genre genre)
    {
        var books = await _manager.BookService.GetAllBooksByGenre(genre);
        return Ok(books);
    }

    [Route("languages/{language}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByLanguage(Language language)
    {
        var books = await _manager.BookService.GetAllBooksByLanguage(language);
        return Ok(books);
    }

    [Route("authors/{authorId}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByAuthor(long authorId)
    {
        var books = await _manager.BookService.GetAllBooksByAuthor(authorId);
        return Ok(books);
    }

    [Route("publishers/{publisherId}")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooksByPublisher(long publisherId)
    {
        var books = await _manager.BookService.GetAllBooksByPublisher(publisherId);
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
    public async Task<IActionResult> UpdateBook(long id, [FromBody] BookForUpdateDto book)
    {
        await _manager.BookService.UpdateBook(id, book);
        return Ok();
    }

    
}