using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Queries;

public sealed record GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDto>>;