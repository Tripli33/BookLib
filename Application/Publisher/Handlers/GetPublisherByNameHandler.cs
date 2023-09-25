using Application.Publisher.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Handlers;

public class GetPublisherByNameHandler : IRequestHandler<GetPublisherByNameQuery, PublisherDto>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetPublisherByNameHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<PublisherDto> Handle(GetPublisherByNameQuery request, CancellationToken cancellationToken)
    {
        var publisher = await _repositoryManager.Publisher.GetPublisher(request.PublisherName);
        return publisher ?? throw new PublisherNotFoundException(request.PublisherName);
    }
}