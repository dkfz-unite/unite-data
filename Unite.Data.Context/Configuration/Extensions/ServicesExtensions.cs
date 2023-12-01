using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Unite.Data.Context.Configuration.Options;
using Unite.Data.Context.Repositories;

namespace Unite.Data.Context.Configuration.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddTransient<DomainDbContext>();

        return services;
    }

    public static IServiceCollection AddDatabaseFactory(IServiceCollection services, ISqlOptions options)
    {
        services.AddDbContextFactory<DomainDbContext>(builder =>
        {
            builder.UseNpgsql(DomainDbContext.CreateConnectionString(options));
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<DonorsRepository>();
        services.AddTransient<SpecimensRepository>();
        services.AddTransient<GenesRepository>();
        services.AddTransient<VariantsRepository>();
        services.AddTransient<ImagesRepository>();

        return services;
    }
}
