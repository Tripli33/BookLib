using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.CustomerBook.Queries;

public record GetCustomerBookQuery(long CustomerId, long BookId) : IRequest<ExtendBookDto>;