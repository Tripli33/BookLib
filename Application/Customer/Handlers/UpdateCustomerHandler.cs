using Application.Customer.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Customer.Handlers;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private IRepositoryManager _repositoryManager;

    public UpdateCustomerHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Customer.CustomerExists(request.Id))
        throw new CustomerNotFoundException(request.Id);
        _repositoryManager.Customer.UpdateCustomer(request.Id, request.Customer);
        return Unit.Value;
    }
}