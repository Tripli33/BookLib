using Application.Author.Commands;
using Contracts;
using MediatR;

namespace Application.Author.Handlers;

public sealed class AddAuthorHandler : IRequestHandler<AddAuthorCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public AddAuthorHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    
    public Task<Unit> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        _repositoryManager.Author.AddAuthor(request.Author);
        return Task.FromResult(Unit.Value);
    }
}