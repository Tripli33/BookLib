using Shared.DataTransferObjects.Author;

namespace Contracts;

public interface IAuthorRepository
{
    Task<IEnumerable<AuthorDto>> GetAllAuthors();
    Task<AuthorDto> GetAuthor(long id);
    Task<AuthorDto> GetAuthor(string authorName);
    void AddAuthor(AuthorForAddDto author);
    void DeleteAuthor(long id);
    void UpdateAuthor(long id, AuthorForUpdateDto author);
    Task<bool> AuthorExists(long id);
    Task<bool> AuthorExists(string authorName);
}