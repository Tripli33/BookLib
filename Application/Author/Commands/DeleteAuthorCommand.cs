using MediatR;

namespace Application.Author.Commands;

public sealed record DeleteAuthorCommand(long Id) : IRequest<Unit>;