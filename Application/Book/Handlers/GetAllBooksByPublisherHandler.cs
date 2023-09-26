using Application.Book.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers;

public class GetAllBooksByPublisherHandler : IRequestHandler<GetAllBooksByPublishQuery, IEnumerable<ExtendBookDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllBooksByPublisherHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<IEnumerable<ExtendBookDto>> Handle(GetAllBooksByPublishQuery request, CancellationToken cancellationToken)
    {
        var publisher = await _repositoryManager.Publisher.GetPublisher(request.PublisherName)
        ?? throw new PublisherNotFoundException(request.PublisherName);
        return await _repositoryManager.Book.GetAllBooksByPublisher(publisher);;
    }
}