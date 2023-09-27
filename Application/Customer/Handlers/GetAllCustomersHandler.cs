using Application.Customer.Queries;
using Contracts;
using MediatR;
using Shared.DataTransferObjects.Customer;

namespace Application.Customer.Handlers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllCustomersHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return _repositoryManager.Customer.GetAllCustomers();
    }
}