using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Shared.Interfaces;

public interface IFundamentalDataService
{
    Task<FundamentalData?> GetFundamentalDataAsync(string symbol);
    Task<Dictionary<string, FundamentalData>> GetBulkFundamentalDataAsync(IEnumerable<string> symbols);
}
