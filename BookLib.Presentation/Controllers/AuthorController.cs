using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Author;

namespace BookLib.Presentation.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IServiceManager _manager;
    public AuthorController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _manager.AuthorService.GetAllAuthors();
        return Ok(authors.OrderBy(author => author.AuthorId));
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] AuthorForAddDto author)
    {
        _manager.AuthorService.AddAuthor(author);
        return Ok();
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<IActionResult> GetAuthor(long id)
    {
        var author = await _manager.AuthorService.GetAuthor(id);
        return Ok(author);
    }

    [Route("{authorName}")]
    [HttpGet]
    public async Task<IActionResult> GetAuthor(string authorName)
    {
        var author = await _manager.AuthorService.GetAuthor(authorName);
        return Ok(author);
    }

    [Route("{id:long}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAuthor(long id)
    {
        await _manager.AuthorService.DeleteAuthor(id);
        return Ok();
    }

    [Route("{id:long}")]
    [HttpPut]
    public async Task<IActionResult> UpdateAuthor(long id, [FromBody] AuthorForUpdateDto author)
    {
        await _manager.AuthorService.UpdateAuthor(id, author);
        return Ok();
    }
    
}