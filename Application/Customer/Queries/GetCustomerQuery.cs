using MediatR;
using Shared.DataTransferObjects.Customer;

namespace Application.Customer.Queries;

public record GetCustomerQuery(long Id) : IRequest<CustomerDto>;