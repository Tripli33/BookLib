using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetAllBooksByAuthorQuery(string AuthorName) : IRequest<IEnumerable<ExtendBookDto>>;