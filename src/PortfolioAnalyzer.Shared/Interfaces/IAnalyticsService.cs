using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Shared.Interfaces;

public interface IAnalyticsService
{
    Task<PortfolioAnalytics> CalculateAnalyticsAsync(Portfolio portfolio);
}
