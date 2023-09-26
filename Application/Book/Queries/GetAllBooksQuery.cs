using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetAllBooksQuery : IRequest<IEnumerable<ExtendBookDto>>;