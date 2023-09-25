using Application.Publisher.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Publisher.Handlers;

public class DeletePublisherHandler : IRequestHandler<DeletePublisherCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeletePublisherHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Publisher.PublisherExists(request.Id))
        throw new PublisherNotFoundException(request.Id);
        _repositoryManager.Publisher.DeletePublisher(request.Id);
        return Unit.Value;
    }
}