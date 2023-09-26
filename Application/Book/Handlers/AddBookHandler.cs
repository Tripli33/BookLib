using Application.Book.Commands;
using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Author;
using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.Publisher;

namespace Application.Book.Handlers;

public class AddBookHandler : IRequestHandler<AddBookCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public AddBookHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        AuthorDto author = new();
        PublisherDto publisher = new();
        if (request.Book.AuthorName is not null)
            author = await _repositoryManager.Author.GetAuthor(request.Book.AuthorName)
            ?? throw new AuthorNotFoundException(request.Book.AuthorName);
        if (request.Book.PublisherName is not null)
            publisher = await _repositoryManager.Publisher.GetPublisher(request.Book.PublisherName)
            ?? throw new PublisherNotFoundException(request.Book.PublisherName);
        if (!EnumExtensions.IsEnumNameValid<Genre>(request.Book.Genre))
            throw new GenreNotFoundException(request.Book.Genre);
        if (!EnumExtensions.IsEnumNameValid<Language>(request.Book.Language))
            throw new LanguageNotFoundException(request.Book.Language);
        _repositoryManager.Book.AddBook
        (
                request.Book.ConvertExtendBookForManipulationDtoToBookForManipulationDto<BookForAddDto>(author, publisher)
        );
        return Unit.Value;
    }
}