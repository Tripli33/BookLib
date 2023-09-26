using Application.Book.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Book.Handlers;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private IRepositoryManager _repositoryManager;

    public DeleteBookHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Book.BookExists(request.Id))
        throw new BookNotFoundException(request.Id);
        _repositoryManager.Book.DeleteBook(request.Id);
        return Unit.Value;
    }
}