using MediatR;
using Shared.DataTransferObjects.Customer;

namespace Application.Customer.Commands;

public record UpdateCustomerCommand(long Id, CustomerForUpdateDto Customer) : IRequest<Unit>;