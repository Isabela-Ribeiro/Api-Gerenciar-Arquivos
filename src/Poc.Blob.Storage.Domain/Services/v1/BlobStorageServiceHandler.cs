using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Poc.Blob.Storage.Domain.Contracts.v1;
using Poc.Blob.Storage.Domain.Settings.v1;

namespace Poc.Blob.Storage.Domain.Services.v1;

public sealed class BlobStorageServiceHandler : IBlobStorageService
{
    private readonly BlobContainerClient _containerClient;

    public BlobStorageServiceHandler(BlobStorageSettings storageSettings)
    {
        _containerClient = new BlobContainerClient(storageSettings.ConnectionString, storageSettings.ContainerName);
    }

    public Uri Download(string localFilePath)
    {
        var blobClient = _containerClient.GetBlobClient(localFilePath);

        return GetBlobUri(blobClient);
    }

    public async Task<bool> ExistAsync(string localFilePath, CancellationToken cancellationToken)
    {
        var blobClient = _containerClient.GetBlobClient(localFilePath);

        return await blobClient.ExistsAsync(cancellationToken);
    }

    public async Task<int> UploadAsync(Stream stream, string localFilePath, CancellationToken cancellationToken)
    {
        var blobClient = _containerClient.GetBlobClient(localFilePath);

        var result = await blobClient.UploadAsync(stream, true, cancellationToken);

        return result.GetRawResponse().Status;
    }

    public async Task<bool> DeleteAsync(string localFilePath, CancellationToken cancellationToken)
    {
        var blobClient = await _containerClient.DeleteBlobIfExistsAsync(localFilePath, cancellationToken: cancellationToken);

        return blobClient.Value;

    }

    private static Uri GetBlobUri(BlobClient blobClient)
    {
        var blobSasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1));

        return blobClient.GenerateSasUri(blobSasBuilder);
    }
}