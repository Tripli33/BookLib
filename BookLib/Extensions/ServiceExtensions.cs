using Contracts;
using MediatR;
using Repository;
using Service;
using Service.Contracts;

namespace BookLib.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRepositoryManger(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
    public static void ConfigureServiceManger(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }
    public static void ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers().AddApplicationPart(typeof(BookLib.Presentation.AssemblyReference).Assembly);
    }

    public static void ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
    }
    
}