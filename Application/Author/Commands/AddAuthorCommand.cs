using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Commands;

public sealed record AddAuthorCommand(AuthorForAddDto Author) : IRequest<Unit>;