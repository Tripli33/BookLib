using MediatR;
using Shared.DataTransferObjects.Customer;

namespace Application.Customer.Queries;

public record GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>;