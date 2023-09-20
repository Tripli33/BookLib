using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Queries;

public sealed record GetAuthorByIdQuery(long Id) : IRequest<AuthorDto>;