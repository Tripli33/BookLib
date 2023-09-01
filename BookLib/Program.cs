using BookLib.Extensions;
using Contracts;
using Dapper;
using Repository;
using Service;
using Service.Contracts;

var builder = WebApplication.CreateBuilder(args);

DefaultTypeMap.MatchNamesWithUnderscores = true;
builder.Services.AddSingleton<RepositoryContext>();

builder.Services.ConfigureRepositoryManger();
builder.Services.ConfigureServiceManger();

builder.Services.ConfigureControllers();

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
