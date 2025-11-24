namespace PortfolioAnalyzer.Shared.Models;

public class Portfolio
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = "My Portfolio";
    public decimal Cash { get; set; }
    public List<Position> Positions { get; set; } = new();
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    public decimal TotalMarketValue => Positions.Sum(p => p.MarketValue) + Cash;
    public decimal TotalCostBasis => Positions.Sum(p => p.CostBasis) + Cash;
    public decimal TotalUnrealizedPnL => Positions.Sum(p => p.UnrealizedPnL);
    public decimal TotalUnrealizedPnLPercent => TotalCostBasis != 0
        ? (TotalUnrealizedPnL / TotalCostBasis) * 100
        : 0;
}
