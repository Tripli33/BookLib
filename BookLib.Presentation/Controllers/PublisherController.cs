using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace BookLib.Presentation.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IServiceManager _manager;
    public PublisherController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPublishers()
    {
        var publishers = await _manager.PublisherService.GetAllPublishers();
        return Ok(publishers.OrderBy(publisher => publisher.PublisherId));
    }

    [HttpPost]
    public async Task<IActionResult> AddPublisher([FromBody] PublisherForAddDto publisher)
    {
        await _manager.PublisherService.AddPublisher(publisher);
        return Ok();
    }

    [Route("{id:long}")]
    [HttpGet]
    public async Task<IActionResult> GetPublisher(long id)
    {
        var publisher = await _manager.PublisherService.GetPublisher(id);
        return Ok(publisher);
    }

    [Route("{publisherName}")]
    [HttpGet]
    public async Task<IActionResult> GetPublisher(string publisherName)
    {
        var publisher = await _manager.PublisherService.GetPublisher(publisherName);
        return Ok(publisher);
    }

    [Route("{id:long}")]
    [HttpDelete]
    public async Task<IActionResult> DeletePublisher(long id)
    {
        await _manager.PublisherService.DeletePublisher(id);
        return Ok();
    }

    [Route("{id:long}")]
    [HttpPut]
    public async Task<IActionResult> UpdatePublisher(long id, [FromBody] PublisherForUpdateDto publisher)
    {
        await _manager.PublisherService.UpdatePublisher(id, publisher);
        return Ok();
    }
}