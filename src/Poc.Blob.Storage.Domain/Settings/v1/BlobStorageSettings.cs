namespace Poc.Blob.Storage.Domain.Settings.v1;

public sealed class BlobStorageSettings
{
    public static string SessionName => "BlobStorage";

    public string? ContainerName { get; set; }

    public string? ConnectionString { get; set; }
}