using Contracts;
using Dapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Repository;

public class PublisherRepository : IPublisherRepository
{
    private readonly RepositoryContext _context;

    public PublisherRepository(RepositoryContext context)
    {
        _context = context;
    }
    public async Task AddPublisher(PublisherForAddDto publisher)
    {
        var query = @$"INSERT INTO publishers
            (publisher_name) 
            VALUES 
            (@PublisherName)";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, publisher);
    }

    public async Task DeletePublisher(long id)
    {
        var query = @"DELETE FROM publishers
                    WHERE publisher_id = @id";
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<IEnumerable<PublisherDto>> GetAllPublishers()
    {
        var query = "SELECT * FROM publishers";
        using var connection = _context.CreateConnection();
        var publishers = await connection.QueryAsync<PublisherDto>(query);
        return publishers.ToList();
    }

    public async Task<PublisherDto> GetPublisher(long id)
    {
        var query = @"SELECT * FROM publishers
                    WHERE publisher_id = @id";
        using var connection = _context.CreateConnection();
        var publisher = await connection.QueryFirstOrDefaultAsync<PublisherDto>(query, new { id });
        return publisher;
    }

    public async Task<PublisherDto> GetPublisher(string publisherName)
    {
        var query = @"SELECT * FROM publishers
                    WHERE publisher_name = @PublisherName";
        using var connection = _context.CreateConnection();
        var publisher = await connection.QueryFirstOrDefaultAsync<PublisherDto>(query, new { publisherName });
        return publisher;
    }

    public async Task<bool> PublisherExists(long id)
    {
        return await GetPublisher(id) is not null;
    }

    public async Task<bool> PublisherExists(string publisherName)
    {
        return await GetPublisher(publisherName) is not null;
    }

    public async Task UpdatePublisher(long id, PublisherForUpdateDto publisher)
    {
        var query = @"UPDATE publishers SET
                    publisher_name = @PublisherName
                    WHERE publisher_id = @PublisherId";
        using var connection = _context.CreateConnection();
        var temp = publisher.ConvertPublisherForManipulationDtoToPublisher(id);
        await connection.ExecuteAsync(query, temp);
    }
    
}