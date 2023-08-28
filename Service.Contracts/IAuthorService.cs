using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetAuthor(long id);
    Task<Author> GetAuthor(string authorName);
    Task AddAuthor(AuthorForAddDto author);
    Task DeleteAuthor(long id);
    Task UpdateAuthor(long id, AuthorForUpdateDto author);
}