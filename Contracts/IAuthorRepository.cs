using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetAuthor(long id);
    Task<Author> GetAuthor(string authorName);
    Task AddAuthor(AuthorForAddDto author);
    Task DeleteAuthor(long id);
    Task UpdateAuthor(long id, AuthorForUpdateDto author);
    Task<bool> AuthorExists(long id);
    Task<bool> AuthorExists(string authorName);
}