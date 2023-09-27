using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.CustomerBook.Queries;

public record GetAllCustomerBooksQuery(long CustomerId) : IRequest<IEnumerable<ExtendBookDto>>;