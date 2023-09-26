using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Queries;

public sealed record GetBookByIdQuery(long Id) : IRequest<ExtendBookDto>;