using System.Text.Json.Serialization;

namespace Poc.Blob.Storage.Domain.Dtos.v1;

public record DeleteDto
{
    [JsonPropertyName("filePath")]
    public string? FilePath { get; init; }
}