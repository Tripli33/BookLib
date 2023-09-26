using Application.Book.Queries;
using Contracts;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers;

public class GetAllBooksByNameHandler : IRequestHandler<GetAllBooksByNameQuery, IEnumerable<ExtendBookDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllBooksByNameHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<IEnumerable<ExtendBookDto>> Handle(GetAllBooksByNameQuery request, CancellationToken cancellationToken)
    {
        return await _repositoryManager.Book.GetAllBooksByName(request.Name);
    }
}