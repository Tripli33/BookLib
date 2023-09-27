using Application.Customer.Commands;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Customer.Handlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteCustomerHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Customer.CustomerExists(request.Id))
        throw new CustomerNotFoundException(request.Id);
        _repositoryManager.Customer.DeleteCustomer(request.Id);
        return Unit.Value;
    }
}