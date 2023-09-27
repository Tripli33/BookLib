using Application.Customer.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Customer;

namespace Application.Customer.Handlers;

public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetCustomerHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repositoryManager.Customer.GetCustomer(request.Id);
        return customer ?? throw new CustomerNotFoundException(request.Id);
    }
}