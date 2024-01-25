using Microsoft.AspNetCore.Mvc;
using Poc.Blob.Storage.Domain.Contracts.v1;
using Poc.Blob.Storage.Domain.Dtos.v1;

namespace Poc.Blob.Storage.Api.Controllers.Files.v1;

[Route("api/v1/files")]
[ApiController]
public sealed class FilesController : ControllerBase
{
    private readonly IBlobStorageService _storageService;

    public FilesController(IBlobStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet]
    public IActionResult Download([FromQuery(Name = "file-path")] string filePath)
    {
        var result = _storageService.Download(filePath);

        if (result is null)
            return NotFound(new { message = "Arquivo não encontrado." });

        return Ok(new { message = result.AbsoluteUri.ToString() });
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadAsync(IFormFile fromFile, [FromForm(Name = "path")] string path, CancellationToken cancellationToken)
    {
        await using var stream = fromFile.OpenReadStream();

        var filePath = path + "/" + fromFile.FileName;

        var result = await _storageService.UploadAsync(stream, filePath, cancellationToken);

        return Created(string.Empty, new { message = "Arquivo criado ou atualizado." });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteDto deleteDto, CancellationToken cancellationToken)
    {
        var status = await _storageService.DeleteAsync(deleteDto!.FilePath!, cancellationToken);

        if (!status)
            return NotFound(new { message = "Arquivo não encontrado para ser deletado." });

        return Ok(new { message = "Arquivo deletado." });
    }

    [HttpGet("exist")]
    public async Task<IActionResult> ExistAsync([FromQuery(Name = "file-path")] string filePath, CancellationToken cancellationToken)
    {
        var result = await _storageService.ExistAsync(filePath, cancellationToken);

        if (!result)
            return NotFound(new { message = "Arquivo não existe." });

        return Ok(new { message = "Arquivo existe." });
    }
}