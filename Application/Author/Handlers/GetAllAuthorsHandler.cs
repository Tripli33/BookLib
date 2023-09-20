using Application.Author.Queries;
using Contracts;
using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Handlers;

public sealed class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDto>>
{
    private readonly IRepositoryManager _repositoryManager;
    
    public GetAllAuthorsHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        return await _repositoryManager.Author.GetAllAuthors();
    }
}