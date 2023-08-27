using BookLib.Extensions;
using Contracts;
using Dapper;
using Repository;

var builder = WebApplication.CreateBuilder(args);

DefaultTypeMap.MatchNamesWithUnderscores = true;
builder.Services.AddSingleton<RepositoryContext>();

builder.Services.AddControllers();

var app = builder.Build();

app.ConfigureExceptionHandler();

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
