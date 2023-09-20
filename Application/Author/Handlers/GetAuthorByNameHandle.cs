using Application.Author.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Handlers;

public sealed class GetAuthorByNameHandle : IRequestHandler<GetAuthorByNameQuery, AuthorDto> 
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAuthorByNameHandle(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<AuthorDto> Handle(GetAuthorByNameQuery request, CancellationToken cancellationToken)
    {
        var author = await _repositoryManager.Author.GetAuthor(request.AuthorName);
        return author ?? throw new AuthorNotFoundException(request.AuthorName);
    }
}