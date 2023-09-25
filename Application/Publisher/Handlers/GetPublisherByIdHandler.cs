using Application.Publisher.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Handlers;

public class GetPublisherByIdHandler : IRequestHandler<GetPublisherByIdQuery, PublisherDto>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetPublisherByIdHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<PublisherDto> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
    {
        var publisher = await _repositoryManager.Publisher.GetPublisher(request.Id);
        return publisher ?? throw new PublisherNotFoundException(request.Id);
    }
}