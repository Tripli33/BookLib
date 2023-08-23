using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Repository;

public class RepositoryContext
{
    private readonly IConfiguration _configuration;
    private readonly string? _connectionString;
    public RepositoryContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SqlConnection") ?? String.Empty;
    }
    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}