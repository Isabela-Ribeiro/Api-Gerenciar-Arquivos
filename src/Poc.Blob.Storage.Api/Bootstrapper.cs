using Poc.Blob.Storage.Domain.Services.v1;
using Poc.Blob.Storage.Domain.Settings.v1;
using Poc.Blob.Storage.Domain.Contracts.v1;

namespace Poc.Blob.Storage.Api;

public static class Bootstrapper
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBlobStorageService, BlobStorageServiceHandler>();

        return services;
    }

    public static void AppSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection(BlobStorageSettings.SessionName).Get<BlobStorageSettings>());
    }
}