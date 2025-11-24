using PortfolioAnalyzer.Shared.Interfaces;
using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Api.Services;

public class MockFundamentalDataService : IFundamentalDataService
{
    public Task<FundamentalData?> GetFundamentalDataAsync(string symbol)
    {
        // This will be replaced with Alpha Vantage API later
        // For now, returns null as mock data is already in portfolio
        return Task.FromResult<FundamentalData?>(null);
    }

    public Task<Dictionary<string, FundamentalData>> GetBulkFundamentalDataAsync(IEnumerable<string> symbols)
    {
        // This will be replaced with Alpha Vantage API later
        return Task.FromResult(new Dictionary<string, FundamentalData>());
    }
}
