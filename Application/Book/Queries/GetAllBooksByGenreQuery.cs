using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetAllBooksByGenreQuery(string GenreName) : IRequest<IEnumerable<ExtendBookDto>>;