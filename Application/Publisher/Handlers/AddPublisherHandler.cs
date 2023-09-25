using Application.Publisher.Commands;
using Contracts;
using MediatR;

namespace Application.Publisher.Handlers;

public class AddPublisherHandler : IRequestHandler<AddPublisherCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public AddPublisherHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public Task<Unit> Handle(AddPublisherCommand request, CancellationToken cancellationToken)
    {
        _repositoryManager.Publisher.AddPublisher(request.Publisher);
        return Task.FromResult(Unit.Value);
    }
}