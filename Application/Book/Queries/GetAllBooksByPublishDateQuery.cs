using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetAllBooksByPublishDateQuery(DateTime publishDate) : IRequest<IEnumerable<ExtendBookDto>>;
