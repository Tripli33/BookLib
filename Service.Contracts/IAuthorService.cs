using Shared.DataTransferObjects.Author;

namespace Service.Contracts;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAuthors();
    Task<AuthorDto> GetAuthor(long id);
    Task<AuthorDto> GetAuthor(string authorName);
    void AddAuthor(AuthorForAddDto author);
    Task DeleteAuthor(long id);
    Task UpdateAuthor(long id, AuthorForUpdateDto author);
}