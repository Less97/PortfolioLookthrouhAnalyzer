namespace PortfolioAnalyzer.Shared.Models;

public class PortfolioAnalytics
{
    public decimal TotalRevenue { get; set; }
    public decimal TotalFreeCashFlow { get; set; }
    public decimal WeightedRevenueGrowth { get; set; }
    public decimal WeightedEarningsGrowth { get; set; }
    public decimal TotalDividendYield { get; set; }
    public decimal TotalAnnualDividends { get; set; }

    public List<SectorAllocation> SectorAllocations { get; set; } = new();
    public List<PositionContribution> TopContributors { get; set; } = new();
    public List<PositionContribution> TopDetractors { get; set; } = new();
    public List<DividendContribution> DividendBreakdown { get; set; } = new();

    public DateTime CalculatedAt { get; set; } = DateTime.UtcNow;
}

public class SectorAllocation
{
    public string Sector { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public decimal Percentage { get; set; }
    public int PositionCount { get; set; }
}

public class PositionContribution
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public decimal ContributionAmount { get; set; }
    public decimal ContributionPercent { get; set; }
    public decimal Weight { get; set; }
}

public class DividendContribution
{
    public string Symbol { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal AnnualDividend { get; set; }
    public decimal Percentage { get; set; }
    public decimal Yield { get; set; }
}
