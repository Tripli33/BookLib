using Application.Author.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Author.Handlers;

public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteAuthorHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Author.AuthorExists(request.Id))
        throw new AuthorNotFoundException(request.Id);
        _repositoryManager.Author.DeleteAuthor(request.Id);
        return Unit.Value; 
    }
}