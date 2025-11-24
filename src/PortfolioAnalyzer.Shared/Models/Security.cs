namespace PortfolioAnalyzer.Shared.Models;

public class Security
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Isin { get; set; } = string.Empty;
    public string Sector { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public string Exchange { get; set; } = string.Empty;
    public string Currency { get; set; } = "USD";

    public FundamentalData? Fundamentals { get; set; }
}

public class FundamentalData
{
    public string Symbol { get; set; } = string.Empty;
    public decimal MarketCap { get; set; }
    public decimal Revenue { get; set; }
    public decimal FreeCashFlow { get; set; }
    public decimal RevenueGrowth { get; set; }
    public decimal EarningsGrowth { get; set; }
    public decimal DividendYield { get; set; }
    public decimal DividendPerShare { get; set; }
    public decimal PE { get; set; }
    public decimal PB { get; set; }
    public decimal ROE { get; set; }
    public decimal DebtToEquity { get; set; }
    public DateTime LastUpdated { get; set; }
}
