using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Commands;

public sealed record UpdateAuthorCommand(long Id, AuthorForUpdateDto Author): IRequest<Unit>;