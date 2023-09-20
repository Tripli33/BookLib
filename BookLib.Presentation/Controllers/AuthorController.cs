using Application.Author.Commands;
using Application.Author.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Author;

namespace BookLib.Presentation.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _mediator.Send(new GetAllAuthorsQuery());
        return Ok(authors.OrderBy(author => author.AuthorId));
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] AuthorForAddDto author)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        _mediator.Send(new AddAuthorCommand(author));
        return Ok();
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<IActionResult> GetAuthor(long id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery(id));
        return Ok(author);
    }

    [Route("{authorName}")]
    [HttpGet]
    public async Task<IActionResult> GetAuthor(string authorName)
    {
        var author = await _mediator.Send(new GetAuthorByNameQuery(authorName));
        return Ok(author);
    }

    [Route("{id:long}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteAuthor(long id)
    {
        await _mediator.Send(new DeleteAuthorCommand(id));
        return Ok();
    }

    [Route("{id:long}")]
    [HttpPut]
    public async Task<IActionResult> UpdateAuthor(long id, [FromBody] AuthorForUpdateDto author)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        await _mediator.Send(new UpdateAuthorCommand(id, author));
        return Ok();
    }
    
}