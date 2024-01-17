using FluentStorage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace FluentStorageDemo.Api.Controllers;

[ApiController]
[Route("file")]
public class FileController : ControllerBase
{
    private readonly IBlobStorage _storage;

    public FileController(IBlobStorage storage)
    {
        _storage = storage;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        try
        {
            await _storage.WriteAsync(file.FileName, file.OpenReadStream());

            return Ok(new { path = file.FileName });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error uploading file: " + ex.Message);
        }
    }
}
