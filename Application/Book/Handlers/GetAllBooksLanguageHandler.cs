using Application.Book.Queries;
using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers;

public class GetAllBooksLanguageHandler : IRequestHandler<GetAllBooksByLanguageQuery, IEnumerable<ExtendBookDto>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllBooksLanguageHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public Task<IEnumerable<ExtendBookDto>> Handle(GetAllBooksByLanguageQuery request, CancellationToken cancellationToken)
    {
        if (!EnumExtensions.IsEnumNameValid<Language>(request.LanguageName))
            throw new LanguageNotFoundException(request.LanguageName);
        Language language = EnumExtensions.EnumNameToEnum<Language>(request.LanguageName, Language.WithoutLanguage);
        return _repositoryManager.Book.GetAllBooksByLanguage(language);
    }
}