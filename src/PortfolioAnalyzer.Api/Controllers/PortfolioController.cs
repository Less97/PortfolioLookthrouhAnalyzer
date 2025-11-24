using Microsoft.AspNetCore.Mvc;
using PortfolioAnalyzer.Shared.Interfaces;
using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    private readonly IPortfolioService _portfolioService;
    private readonly ILogger<PortfolioController> _logger;

    public PortfolioController(
        IPortfolioService portfolioService,
        ILogger<PortfolioController> logger)
    {
        _portfolioService = portfolioService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<Portfolio>> GetPortfolio()
    {
        try
        {
            var portfolio = await _portfolioService.GetPortfolioAsync();
            return Ok(portfolio);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving portfolio");
            return StatusCode(500, "An error occurred while retrieving the portfolio");
        }
    }

    [HttpPut]
    public async Task<ActionResult<Portfolio>> UpdatePortfolio([FromBody] Portfolio portfolio)
    {
        try
        {
            var updatedPortfolio = await _portfolioService.UpdatePortfolioAsync(portfolio);
            return Ok(updatedPortfolio);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating portfolio");
            return StatusCode(500, "An error occurred while updating the portfolio");
        }
    }

    [HttpPost("import")]
    public async Task<ActionResult<Portfolio>> ImportFromCsv(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file provided");
        }

        try
        {
            using var stream = file.OpenReadStream();
            var portfolio = await _portfolioService.ImportFromCsvAsync(stream);
            return Ok(portfolio);
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, "CSV import is not yet implemented");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importing portfolio from CSV");
            return StatusCode(500, "An error occurred while importing the portfolio");
        }
    }
}
