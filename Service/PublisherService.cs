using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class PublisherService : IPublisherService
{
    private readonly IRepositoryManager _repositoryManager;
    public PublisherService (IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task AddPublisher(PublisherForAddDto publisher)
    {
        await _repositoryManager.Publisher.AddPublisher(publisher);
    }

    public async Task DeletePublisher(long id)
    {
        if (!await _repositoryManager.Publisher.PublisherExists(id))
        throw new PublisherNotFoundException(id);
        await _repositoryManager.Publisher.DeletePublisher(id);
    }

    public async Task<IEnumerable<Publisher>> GetAllPublishers()
    {
        return await _repositoryManager.Publisher.GetAllPublishers();
    }

    public Task<Publisher> GetPublisher(long id)
    {
        var publisher = _repositoryManager.Publisher.GetPublisher(id);
        return publisher ?? throw new PublisherNotFoundException(id);
    }

    public Task<Publisher> GetPublisher(string publisherName)
    {
        var publisher = _repositoryManager.Publisher.GetPublisher(publisherName);
        return publisher ?? throw new PublisherNotFoundException(publisherName);
    }

    public async Task UpdatePublisher(long id, PublisherForUpdateDto publisher)
    {
        if (!await _repositoryManager.Publisher.PublisherExists(id))
        throw new PublisherNotFoundException(id);
        await _repositoryManager.Publisher.UpdatePublisher(id, publisher);
    }
}