using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts;

public interface IAuthorRepository
{
    Task<IEnumerable<AuthorDto>> GetAllAuthors();
    Task<AuthorDto> GetAuthor(long id);
    Task<AuthorDto> GetAuthor(string authorName);
    Task AddAuthor(AuthorForAddDto author);
    Task DeleteAuthor(long id);
    Task UpdateAuthor(long id, AuthorForUpdateDto author);
    Task<bool> AuthorExists(long id);
    Task<bool> AuthorExists(string authorName);
}