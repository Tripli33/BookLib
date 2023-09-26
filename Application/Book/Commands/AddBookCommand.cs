using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Commands;

public sealed record AddBookCommand(ExtendBookForAddDto Book) : IRequest<Unit>;
