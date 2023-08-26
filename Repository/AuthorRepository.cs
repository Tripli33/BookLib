using Contracts;
using Dapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly RepositoryContext _context;

    public AuthorRepository(RepositoryContext context)
    {
        _context = context;
    }
    public async Task AddAuthor(AuthorForAddDto author)
    {
        var query = @$"INSERT INTO authors
            (author_name, description) 
            VALUES 
            (@AuthorName, @Description)";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, author);
    }

    public async Task DeleteAuthor(long id)
    {
        var query = @"DELETE FROM authors
                    WHERE author_id = @id";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        var query = "SELECT * FROM authors";
        using var connection = _context.CreateConnection();
        var authors = await connection.QueryAsync<Author>(query);
        return authors.ToList();
    }

    public async Task<Author> GetAuthor(long id)
    {
        var query = @"SELECT * FROM authors
                    WHERE author_id = @id";
        using var connection = _context.CreateConnection();
        var author = await connection.QueryFirstOrDefaultAsync<Author>(query, new { id });
        return author;
    }

    public async Task<Author> GetAuthor(string authorName)
    {
        var query = @"SELECT * FROM authors
                    WHERE author_name = @authorName";
        using var connection = _context.CreateConnection();
        var author = await connection.QueryFirstOrDefaultAsync<Author>(query, new { authorName });
        return author;
    }

    public async Task UpdateAuthor(long id, AuthorForUpdateDto author)
    {
        var query = @"UPDATE authors SET
                    author_name = @AuthorName, description = @Description
                    WHERE author_id = @AuthorId";
        using var connection = _context.CreateConnection();
        var temp = author.ConvertAuthorForManipulationDtoToAuthor(id);
        await connection.ExecuteAsync(query, temp);
    }
}