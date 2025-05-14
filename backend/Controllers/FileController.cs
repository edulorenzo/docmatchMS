using Microsoft.AspNetCore.Mvc;
using docmatchMS.Services;
using System.Threading.Tasks;

namespace docmatchMS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly FileProcessingService _fileProcessingService;
    private readonly SimilarityService _similarityService;

    public FileController(FileProcessingService fileProcessingService, SimilarityService similarityService)
    {
        _fileProcessingService = fileProcessingService;
        _similarityService = similarityService;
    }

    [HttpPost("match")]
    public async Task<IActionResult> MatchFile([FromBody] MatchRequest matchRequest)
    {
        if (string.IsNullOrWhiteSpace(matchRequest.FilePath) || string.IsNullOrWhiteSpace(matchRequest.TemplateText))
        {
            return BadRequest("File path and template text are required.");
        }

        var fileText = await _fileProcessingService.ExtractTextFromFileAsync(matchRequest.FilePath);
        var score = _similarityService.CalculateJaccardSimilarity(fileText, matchRequest.TemplateText);

        return Ok(new { matchScore = score });
    }
}

public class MatchRequest
{
    public string FilePath { get; set; }
    public string TemplateText { get; set; }
}