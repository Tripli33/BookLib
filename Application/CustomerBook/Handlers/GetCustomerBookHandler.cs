using Application.CustomerBook.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.CustomerBook.Handlers;

public class GetCustomerBookHandler : IRequestHandler<GetCustomerBookQuery, ExtendBookDto>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetCustomerBookHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<ExtendBookDto> Handle(GetCustomerBookQuery request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Customer.CustomerExists(request.CustomerId))
        throw new CustomerNotFoundException(request.CustomerId);
        if (!await _repositoryManager.Book.BookExists(request.BookId))
        throw new BookNotFoundException(request.BookId);
        return await _repositoryManager.CustomerBook.GetCustomerBook(request.CustomerId, request.BookId);
    }
}