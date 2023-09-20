using Application.Author.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Handlers;

public sealed class GetAuthorByIdHandle : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    private readonly IRepositoryManager _repositoryManager;
    
    public GetAuthorByIdHandle(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _repositoryManager.Author.GetAuthor(request.Id);
        return author ?? throw new AuthorNotFoundException(request.Id);
    }
}