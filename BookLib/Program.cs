using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<RepositoryContext>(); 
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
