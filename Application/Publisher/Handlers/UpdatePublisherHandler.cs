using Application.Publisher.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Publisher.Handlers;

public class UpdatePublisherHandler : IRequestHandler<UpdatePublisherCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public UpdatePublisherHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Publisher.PublisherExists(request.Id))
        throw new PublisherNotFoundException(request.Id);
        _repositoryManager.Publisher.UpdatePublisher(request.Id, request.Publisher);
        return Unit.Value;
    }
}