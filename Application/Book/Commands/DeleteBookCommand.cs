using MediatR;

namespace Application.Book.Commands;

public sealed record DeleteBookCommand(long Id) : IRequest<Unit>;