using Application.Author.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Author.Handlers;

public sealed class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public UpdateAuthorHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Author.AuthorExists(request.Id))
        throw new AuthorNotFoundException(request.Id);
        _repositoryManager.Author.UpdateAuthor(request.Id, request.Author);
        return Unit.Value;
    }
}