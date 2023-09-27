using Application.Customer.Commands;
using Contracts;
using MediatR;

namespace Application.Customer.Handlers;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public AddCustomerHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        _repositoryManager.Customer.AddCustomer(request.Customer);
        return Task.FromResult(Unit.Value);
    }
}