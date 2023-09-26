using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetAllBooksByNameQuery(string Name) : IRequest<IEnumerable<ExtendBookDto>>;