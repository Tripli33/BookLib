using Application.Book.Queries;
using Contracts;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<ExtendBookDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllBooksHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public Task<IEnumerable<ExtendBookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return _repositoryManager.Book.GetAllBooks();
    }
}