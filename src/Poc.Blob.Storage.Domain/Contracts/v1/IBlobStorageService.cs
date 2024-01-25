namespace Poc.Blob.Storage.Domain.Contracts.v1;

public interface IBlobStorageService
{
    Uri Download(string localFilePath);

    Task<bool> ExistAsync(string localFilePath, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(string localFilePath, CancellationToken cancellationToken);

    Task<int> UploadAsync(Stream stream, string localFilePath, CancellationToken cancellationToken);
}