using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repositoryManager;
    public AuthorService (IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task AddAuthor(AuthorForAddDto author)
    {
        await _repositoryManager.Author.AddAuthor(author);
    }

    public async Task DeleteAuthor(long id)
    {
        if (!await _repositoryManager.Author.AuthorExists(id))
        throw new AuthorNotFoundException(id);
        await _repositoryManager.Author.DeleteAuthor(id);
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _repositoryManager.Author.GetAllAuthors();
    }

    public async Task<Author> GetAuthor(long id)
    {
        var author = await _repositoryManager.Author.GetAuthor(id);
        return author ?? throw new AuthorNotFoundException(id);
    }

    public async Task<Author> GetAuthor(string authorName)
    {
        var author = await _repositoryManager.Author.GetAuthor(authorName);
        return author ?? throw new AuthorNotFoundException(authorName);
    }

    public async Task UpdateAuthor(long id, AuthorForUpdateDto author)
    {
        if (!await _repositoryManager.Author.AuthorExists(id))
        throw new AuthorNotFoundException(id);
        await _repositoryManager.Author.UpdateAuthor(id, author);
    }
}