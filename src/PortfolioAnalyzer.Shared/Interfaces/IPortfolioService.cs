using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Shared.Interfaces;

public interface IPortfolioService
{
    Task<Portfolio> GetPortfolioAsync();
    Task<Portfolio> UpdatePortfolioAsync(Portfolio portfolio);
    Task<Portfolio> ImportFromCsvAsync(Stream csvStream);
}
