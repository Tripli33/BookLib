using Application.Book.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers;

public class GetAllBooksByAuthorHandler : IRequestHandler<GetAllBooksByAuthorQuery, IEnumerable<ExtendBookDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllBooksByAuthorHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<IEnumerable<ExtendBookDto>> Handle(GetAllBooksByAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _repositoryManager.Author.GetAuthor(request.AuthorName)
        ?? throw new AuthorNotFoundException(request.AuthorName);
        return await _repositoryManager.Book.GetAllBooksByAuthor(author);
    }
}