using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects.Author;

namespace Service;

public class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repositoryManager;
    public AuthorService (IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public void AddAuthor(AuthorForAddDto author)
    {
        _repositoryManager.Author.AddAuthor(author);
    }

    public async Task DeleteAuthor(long id)
    {
        if (!await _repositoryManager.Author.AuthorExists(id))
        throw new AuthorNotFoundException(id);
        _repositoryManager.Author.DeleteAuthor(id);
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthors()
    {
        return await _repositoryManager.Author.GetAllAuthors();
    }

    public async Task<AuthorDto> GetAuthor(long id)
    {
        var author = await _repositoryManager.Author.GetAuthor(id);
        return author ?? throw new AuthorNotFoundException(id);
    }

    public async Task<AuthorDto> GetAuthor(string authorName)
    {
        var author = await _repositoryManager.Author.GetAuthor(authorName);
        return author ?? throw new AuthorNotFoundException(authorName);
    }

    public async Task UpdateAuthor(long id, AuthorForUpdateDto author)
    {
        if (!await _repositoryManager.Author.AuthorExists(id))
        throw new AuthorNotFoundException(id);
        _repositoryManager.Author.UpdateAuthor(id, author);
    }
}