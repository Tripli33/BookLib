using MediatR;

namespace Application.Customer.Commands;

public record DeleteCustomerCommand(long Id) : IRequest<Unit>;