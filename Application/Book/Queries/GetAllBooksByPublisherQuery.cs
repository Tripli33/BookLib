using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetAllBooksByPublishQuery(string PublisherName) : IRequest<IEnumerable<ExtendBookDto>>;
