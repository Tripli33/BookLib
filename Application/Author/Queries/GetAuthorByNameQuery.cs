using MediatR;
using Shared.DataTransferObjects.Author;

namespace Application.Author.Queries;

public sealed record GetAuthorByNameQuery(string AuthorName) : IRequest<AuthorDto>;