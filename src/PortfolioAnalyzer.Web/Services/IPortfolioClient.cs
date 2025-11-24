using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Web.Services;

public interface IPortfolioClient
{
    Task<Portfolio?> GetPortfolioAsync();
    Task<PortfolioAnalytics?> GetAnalyticsAsync();
}
