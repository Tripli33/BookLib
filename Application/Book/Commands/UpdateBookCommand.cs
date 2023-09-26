using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Commands;

public sealed record UpdateBookCommand(long Id, ExtendBookForUpdateDto Book) : IRequest<Unit>;