using Application.CustomerBook.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.CustomerBook.Handlers;

public class GetAllCustomerBooksHandler : IRequestHandler<GetAllCustomerBooksQuery, IEnumerable<ExtendBookDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllCustomerBooksHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<IEnumerable<ExtendBookDto>> Handle(GetAllCustomerBooksQuery request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Customer.CustomerExists(request.CustomerId))
        throw new CustomerNotFoundException(request.CustomerId);
        return await _repositoryManager.CustomerBook.GetAllCustomerBooks(request.CustomerId);
    }
}