using Application.Book.Queries;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ExtendBookDto>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetBookByIdHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<ExtendBookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _repositoryManager.Book.GetBook(request.Id);
        return book ?? throw new BookNotFoundException(request.Id);
    }
}