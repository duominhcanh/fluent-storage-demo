using Amazon.Runtime;
using FluentStorage;
using FluentStorage.Blobs;
using Microsoft.Extensions.DependencyInjection;

namespace FluentStorageDemo.BlobStorage.DependencyInjection;

public static class DependencyProvider
{
    public static IServiceCollection AddDiskBlobStorage(
        this IServiceCollection services,
        string path
    )
    {
        services.AddScoped<IBlobStorage>(
            factory => StorageFactory.Blobs.FromConnectionString($"disk://path={path}")
        );

        return services;
    }

    public static IServiceCollection AddS3BlobStorage(
        this IServiceCollection services,
        AWSCredentials credentials,
        string bucketName,
        string region
    )
    {
        services.AddScoped<IBlobStorage>(
            factory => StorageFactory.Blobs.AwsS3(credentials, bucketName, region)
        );

        return services;
    }
}
