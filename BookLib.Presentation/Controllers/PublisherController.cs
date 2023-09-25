using Application.Publisher.Commands;
using Application.Publisher.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Publisher;

namespace BookLib.Presentation.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IMediator _mediator;
    public PublisherController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPublishers()
    {
        var publishers = await _mediator.Send(new GetAllPublishersQuery());
        return Ok(publishers.OrderBy(publisher => publisher.PublisherId));
    }

    [HttpPost]
    public IActionResult AddPublisher([FromBody] PublisherForAddDto publisher)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        _mediator.Send(new AddPublisherCommand(publisher));
        return Ok();
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<IActionResult> GetPublisher(long id)
    {
        var publisher = await _mediator.Send(new GetPublisherByIdQuery(id));
        return Ok(publisher);
    }

    [Route("{publisherName}")]
    [HttpGet]
    public async Task<IActionResult> GetPublisher(string publisherName)
    {
        var publisher = await _mediator.Send(new GetPublisherByNameQuery(publisherName));
        return Ok(publisher);
    }

    [Route("{id:long}")]
    [HttpDelete]
    public async Task<IActionResult> DeletePublisher(long id)
    {
        await _mediator.Send(new DeletePublisherCommand(id));
        return Ok();
    }

    [Route("{id:long}")]
    [HttpPut]
    public async Task<IActionResult> UpdatePublisher(long id, [FromBody] PublisherForUpdateDto publisher)
    {
        await _mediator.Send(new UpdatePublisherCommand(id, publisher));
        return Ok();
    }
}