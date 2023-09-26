using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetAllBooksByLanguageQuery(string LanguageName) : IRequest<IEnumerable<ExtendBookDto>>;