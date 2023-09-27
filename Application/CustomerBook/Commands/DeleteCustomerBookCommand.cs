using MediatR;

namespace Application.CustomerBook.Commands;

public record DeleteCustomerBookCommand(long CustomerId, long BookId) : IRequest<Unit>;