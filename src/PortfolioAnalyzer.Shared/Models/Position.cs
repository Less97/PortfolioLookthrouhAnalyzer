namespace PortfolioAnalyzer.Shared.Models;

public class Position
{
    public string Symbol { get; set; } = string.Empty;
    public Security? Security { get; set; }
    public decimal Quantity { get; set; }
    public decimal AverageCost { get; set; }
    public decimal CurrentPrice { get; set; }
    public decimal MarketValue => Quantity * CurrentPrice;
    public decimal CostBasis => Quantity * AverageCost;
    public decimal UnrealizedPnL => MarketValue - CostBasis;
    public decimal UnrealizedPnLPercent => CostBasis != 0 ? (UnrealizedPnL / CostBasis) * 100 : 0;

    public DateTime PurchaseDate { get; set; }
    public DateTime? LastUpdated { get; set; }
}
