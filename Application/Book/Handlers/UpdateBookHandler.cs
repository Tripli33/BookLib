using Application.Book.Commands;
using Contracts;
using Entities.Enums;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects.Author;
using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.Publisher;

namespace Application.Book.Handlers;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IRepositoryManager _repositoryManager;

    public UpdateBookHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.Book.BookExists(request.Id))
        throw new BookNotFoundException(request.Id);
        AuthorDto author = new();
        PublisherDto publisher = new();
        if (request.Book.AuthorName is not null)
            author = await _repositoryManager.Author.GetAuthor(request.Book.AuthorName)
            ?? throw new AuthorNotFoundException(request.Book.AuthorName);
        if (request.Book .PublisherName is not null)
            publisher = await _repositoryManager.Publisher.GetPublisher(request.Book.PublisherName)
            ?? throw new PublisherNotFoundException(request.Book.PublisherName);
        if (!EnumExtensions.IsEnumNameValid<Genre>(request.Book.Genre))
            throw new GenreNotFoundException(request.Book.Genre);
        if (!EnumExtensions.IsEnumNameValid<Language>(request.Book.Language))
            throw new LanguageNotFoundException(request.Book.Language);
        _repositoryManager.Book.UpdateBook(
            request.Id, 
            request.Book.ConvertExtendBookForManipulationDtoToBookForManipulationDto<BookForUpdateDto>(author, publisher)
        );
        return Unit.Value;
    }
}