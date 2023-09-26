using Application.Book.Queries;
using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers;

public class GetAllBooksByGenreHandler : IRequestHandler<GetAllBooksByGenreQuery, IEnumerable<ExtendBookDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllBooksByGenreHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<IEnumerable<ExtendBookDto>> Handle(GetAllBooksByGenreQuery request, CancellationToken cancellationToken)
    {
        if (!EnumExtensions.IsEnumNameValid<Genre>(request.GenreName))
            throw new GenreNotFoundException(request.GenreName);
        Genre genre = EnumExtensions.EnumNameToEnum<Genre>(request.GenreName, Genre.WithoutGenre);
        return await _repositoryManager.Book.GetAllBooksByGenre(genre);
    }
}