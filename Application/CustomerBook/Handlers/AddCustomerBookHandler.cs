using Application.CustomerBook.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.CustomerBook.Handlers;

public class AddCustomerBookHandler : IRequestHandler<AddCustomerBookCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public AddCustomerBookHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(AddCustomerBookCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Customer.CustomerExists(request.CustomerId))
        throw new CustomerNotFoundException(request.CustomerId);
        if (!await _repositoryManager.Book.BookExists(request.Book.BookId))
        throw new BookNotFoundException(request.Book.BookId);
        if (await _repositoryManager.CustomerBook.CustomerBookExists(request.CustomerId, request.Book.BookId))
        throw new CustomerBookConflictException(request.CustomerId, request.Book.BookId);
        _repositoryManager.CustomerBook.AddCustomerBook(request.CustomerId, request.Book);
        return Unit.Value;
    }
}