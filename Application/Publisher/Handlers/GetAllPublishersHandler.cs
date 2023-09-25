using Application.Publisher.Queries;
using Contracts;
using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Handlers;

public class GetAllPublishersHandler : IRequestHandler<GetAllPublishersQuery, IEnumerable<PublisherDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllPublishersHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<PublisherDto>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
    {
        return await _repositoryManager.Publisher.GetAllPublishers();
    }
}