using MediatR;
using Shared.DataTransferObjects.Customer;

namespace Application.Customer.Commands;

public record AddCustomerCommand(CustomerForAddDto Customer) : IRequest<Unit>;