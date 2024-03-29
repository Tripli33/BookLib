using Contracts;
using Dapper;
using Shared.DataTransferObjects.Author;

namespace Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly RepositoryContext _context;

    public AuthorRepository(RepositoryContext context)
    {
        _context = context;
    }
    public void AddAuthor(AuthorForAddDto author)
    {
        var query = @$"INSERT INTO authors
            (author_name, description) 
            VALUES 
            (@AuthorName, @Description)";
        using var connection = _context.CreateConnection();
        connection.Execute(query, author);
    }

    public async Task<bool> AuthorExists(long id)
    {
        return await GetAuthor(id) is not null;
    }

    public async Task<bool> AuthorExists(string authorName)
    {
        return await GetAuthor(authorName) is not null;
    }

    public void DeleteAuthor(long id)
    {
        var query = @"DELETE FROM authors
                    WHERE author_id = @id";
        using var connection = _context.CreateConnection();
        connection.Execute(query, new { id });
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthors()
    {
        var query = "SELECT * FROM authors";
        using var connection = _context.CreateConnection();
        var authors = await connection.QueryAsync<AuthorDto>(query);
        return authors.ToList();
    }

    public async Task<AuthorDto> GetAuthor(long id)
    {
        var query = @"SELECT * FROM authors
                    WHERE author_id = @id";
        using var connection = _context.CreateConnection();
        var author = await connection.QueryFirstOrDefaultAsync<AuthorDto>(query, new { id });
        return author;
    }

    public async Task<AuthorDto> GetAuthor(string authorName)
    {
        var query = @"SELECT * FROM authors
                    WHERE author_name = @authorName";
        using var connection = _context.CreateConnection();
        var author = await connection.QueryFirstOrDefaultAsync<AuthorDto>(query, new { authorName });
        return author;
    }

    public void UpdateAuthor(long id, AuthorForUpdateDto author)
    {
        var query = @"UPDATE authors SET
                    author_name = @AuthorName, description = @Description
                    WHERE author_id = @AuthorId";
        using var connection = _context.CreateConnection();
        var temp = author.ConvertAuthorForManipulationToAuthorDto(id);
        connection.Execute(query, temp);
    }
}