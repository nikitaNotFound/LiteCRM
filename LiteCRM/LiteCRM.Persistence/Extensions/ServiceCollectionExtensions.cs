using LiteCRM.Application.Contracts;
using LiteCRM.Persistence.Options;
using LiteCRM.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Raven.DependencyInjection;

namespace LiteCRM.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        Action<DocumentStoreOptions> bind)
    {
        var options = new DocumentStoreOptions();
        bind(options);

        if (options.Url is null || options.Database is null)
        {
            throw new ArgumentNullException();
        }

        services.AddRavenDbDocStore(ravenOptions =>
        {
            ravenOptions.Settings!.Urls = new[] {options.Url};
            ravenOptions.Settings.DatabaseName = options.Database;
        });
        services.AddRavenDbAsyncSession();

        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<IStoreItemRepository, StoreItemRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}