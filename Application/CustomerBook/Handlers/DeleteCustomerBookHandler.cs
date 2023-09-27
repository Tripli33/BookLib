using Application.CustomerBook.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.CustomerBook.Handlers;

public class DeleteCustomerBookHandler : IRequestHandler<DeleteCustomerBookCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteCustomerBookHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(DeleteCustomerBookCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Customer.CustomerExists(request.CustomerId))
        throw new CustomerNotFoundException(request.CustomerId);
        if (!await _repositoryManager.Book.BookExists(request.BookId))
        throw new BookNotFoundException(request.BookId);
        _repositoryManager.CustomerBook.DeleteCustomerBook(request.CustomerId, request.BookId);
        return Unit.Value;
    }
}