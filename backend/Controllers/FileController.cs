using Microsoft.AspNetCore.Mvc;

namespace docmatchMS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    [HttpPost("upload")]
    public IActionResult UploadFile(IFormFile file)
    {
        // TODO: Add logic to process and store the file
        return Ok(new { message = "File uploaded successfully" });
    }
}