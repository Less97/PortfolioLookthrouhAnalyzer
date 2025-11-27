using Microsoft.AspNetCore.Mvc;
using PortfolioAnalyzer.Shared.Interfaces;
using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IPortfolioService _portfolioService;
    private readonly IAnalyticsService _analyticsService;
    private readonly ILogger<AnalyticsController> _logger;

    public AnalyticsController(
        IPortfolioService portfolioService,
        IAnalyticsService analyticsService,
        ILogger<AnalyticsController> logger)
    {
        _portfolioService = portfolioService;
        _analyticsService = analyticsService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<PortfolioAnalytics>> GetAnalytics()
    {
        try
        {
            _logger.LogWarning("=== API VERSION: 2024-11-27-v2 ===");
            var portfolio = await _portfolioService.GetPortfolioAsync();
            _logger.LogWarning($"Portfolio Total Market Value: {portfolio.TotalMarketValue:N0}");
            _logger.LogWarning($"Portfolio Positions Count: {portfolio.Positions.Count}");
            _logger.LogWarning($"Portfolio Cash: {portfolio.Cash:N0}");

            var analytics = await _analyticsService.CalculateAnalyticsAsync(portfolio);
            _logger.LogWarning($"Calculated Total Revenue: {analytics.TotalRevenue:N0}");
            _logger.LogWarning($"Calculated Total FCF: {analytics.TotalFreeCashFlow:N0}");

            return Ok(analytics);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calculating analytics");
            return StatusCode(500, "An error occurred while calculating analytics");
        }
    }
}
