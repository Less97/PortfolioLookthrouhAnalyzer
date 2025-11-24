using PortfolioAnalyzer.Shared.Interfaces;
using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Api.Services;

public class MockPortfolioService : IPortfolioService
{
    private Portfolio _portfolio;

    public MockPortfolioService()
    {
        _portfolio = CreateMockPortfolio();
    }

    public Task<Portfolio> GetPortfolioAsync()
    {
        return Task.FromResult(_portfolio);
    }

    public Task<Portfolio> UpdatePortfolioAsync(Portfolio portfolio)
    {
        _portfolio = portfolio;
        return Task.FromResult(_portfolio);
    }

    public Task<Portfolio> ImportFromCsvAsync(Stream csvStream)
    {
        // TODO: Implement CSV import
        throw new NotImplementedException("CSV import will be implemented in a future update");
    }

    private static Portfolio CreateMockPortfolio()
    {
        var portfolio = new Portfolio
        {
            Name = "Sample Investment Portfolio",
            Cash = 25000m,
            LastUpdated = DateTime.UtcNow
        };

        portfolio.Positions = new List<Position>
        {
            new Position
            {
                Symbol = "AAPL",
                Quantity = 150m,
                AverageCost = 145.50m,
                CurrentPrice = 178.25m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-18),
                Security = new Security
                {
                    Symbol = "AAPL",
                    Name = "Apple Inc.",
                    Isin = "US0378331005",
                    Sector = "Technology",
                    Industry = "Consumer Electronics",
                    Exchange = "NASDAQ",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "AAPL",
                        MarketCap = 2800000000000m,
                        Revenue = 383285000000m,
                        FreeCashFlow = 99584000000m,
                        RevenueGrowth = 7.8m,
                        EarningsGrowth = 13.4m,
                        DividendYield = 0.52m,
                        DividendPerShare = 0.96m,
                        PE = 28.5m,
                        PB = 45.2m,
                        ROE = 160.5m,
                        DebtToEquity = 181.3m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            },
            new Position
            {
                Symbol = "MSFT",
                Quantity = 100m,
                AverageCost = 310.20m,
                CurrentPrice = 378.50m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-24),
                Security = new Security
                {
                    Symbol = "MSFT",
                    Name = "Microsoft Corporation",
                    Isin = "US5949181045",
                    Sector = "Technology",
                    Industry = "Software",
                    Exchange = "NASDAQ",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "MSFT",
                        MarketCap = 2810000000000m,
                        Revenue = 211915000000m,
                        FreeCashFlow = 71066000000m,
                        RevenueGrowth = 15.7m,
                        EarningsGrowth = 22.1m,
                        DividendYield = 0.78m,
                        DividendPerShare = 3.00m,
                        PE = 35.8m,
                        PB = 12.5m,
                        ROE = 42.8m,
                        DebtToEquity = 52.1m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            },
            new Position
            {
                Symbol = "JNJ",
                Quantity = 80m,
                AverageCost = 162.30m,
                CurrentPrice = 155.75m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-12),
                Security = new Security
                {
                    Symbol = "JNJ",
                    Name = "Johnson & Johnson",
                    Isin = "US4781601046",
                    Sector = "Healthcare",
                    Industry = "Pharmaceuticals",
                    Exchange = "NYSE",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "JNJ",
                        MarketCap = 382000000000m,
                        Revenue = 85159000000m,
                        FreeCashFlow = 18500000000m,
                        RevenueGrowth = 5.3m,
                        EarningsGrowth = 8.7m,
                        DividendYield = 3.12m,
                        DividendPerShare = 4.76m,
                        PE = 24.3m,
                        PB = 5.8m,
                        ROE = 25.6m,
                        DebtToEquity = 45.7m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            },
            new Position
            {
                Symbol = "V",
                Quantity = 60m,
                AverageCost = 225.80m,
                CurrentPrice = 265.40m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-15),
                Security = new Security
                {
                    Symbol = "V",
                    Name = "Visa Inc.",
                    Isin = "US92826C8394",
                    Sector = "Financial Services",
                    Industry = "Credit Services",
                    Exchange = "NYSE",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "V",
                        MarketCap = 545000000000m,
                        Revenue = 32653000000m,
                        FreeCashFlow = 18200000000m,
                        RevenueGrowth = 11.4m,
                        EarningsGrowth = 17.8m,
                        DividendYield = 0.72m,
                        DividendPerShare = 1.94m,
                        PE = 32.1m,
                        PB = 13.2m,
                        ROE = 45.3m,
                        DebtToEquity = 65.8m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            },
            new Position
            {
                Symbol = "PG",
                Quantity = 90m,
                AverageCost = 142.60m,
                CurrentPrice = 158.30m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-20),
                Security = new Security
                {
                    Symbol = "PG",
                    Name = "Procter & Gamble Co.",
                    Isin = "US7427181091",
                    Sector = "Consumer Defensive",
                    Industry = "Household Products",
                    Exchange = "NYSE",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "PG",
                        MarketCap = 378000000000m,
                        Revenue = 82006000000m,
                        FreeCashFlow = 15800000000m,
                        RevenueGrowth = 3.2m,
                        EarningsGrowth = 6.5m,
                        DividendYield = 2.45m,
                        DividendPerShare = 3.89m,
                        PE = 25.7m,
                        PB = 7.9m,
                        ROE = 32.1m,
                        DebtToEquity = 51.2m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            },
            new Position
            {
                Symbol = "GOOGL",
                Quantity = 75m,
                AverageCost = 128.40m,
                CurrentPrice = 142.80m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-10),
                Security = new Security
                {
                    Symbol = "GOOGL",
                    Name = "Alphabet Inc.",
                    Isin = "US02079K3059",
                    Sector = "Technology",
                    Industry = "Internet Services",
                    Exchange = "NASDAQ",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "GOOGL",
                        MarketCap = 1780000000000m,
                        Revenue = 307394000000m,
                        FreeCashFlow = 69495000000m,
                        RevenueGrowth = 8.7m,
                        EarningsGrowth = 15.2m,
                        DividendYield = 0.0m,
                        DividendPerShare = 0.0m,
                        PE = 26.3m,
                        PB = 6.2m,
                        ROE = 28.4m,
                        DebtToEquity = 12.8m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            },
            new Position
            {
                Symbol = "XOM",
                Quantity = 120m,
                AverageCost = 98.50m,
                CurrentPrice = 103.25m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-8),
                Security = new Security
                {
                    Symbol = "XOM",
                    Name = "Exxon Mobil Corporation",
                    Isin = "US30231G1022",
                    Sector = "Energy",
                    Industry = "Oil & Gas",
                    Exchange = "NYSE",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "XOM",
                        MarketCap = 420000000000m,
                        Revenue = 334704000000m,
                        FreeCashFlow = 55200000000m,
                        RevenueGrowth = -2.3m,
                        EarningsGrowth = -35.2m,
                        DividendYield = 3.48m,
                        DividendPerShare = 3.64m,
                        PE = 11.2m,
                        PB = 2.1m,
                        ROE = 19.8m,
                        DebtToEquity = 23.4m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            },
            new Position
            {
                Symbol = "NVDA",
                Quantity = 45m,
                AverageCost = 425.30m,
                CurrentPrice = 495.20m,
                PurchaseDate = DateTime.UtcNow.AddMonths(-6),
                Security = new Security
                {
                    Symbol = "NVDA",
                    Name = "NVIDIA Corporation",
                    Isin = "US67066G1040",
                    Sector = "Technology",
                    Industry = "Semiconductors",
                    Exchange = "NASDAQ",
                    Currency = "USD",
                    Fundamentals = new FundamentalData
                    {
                        Symbol = "NVDA",
                        MarketCap = 1220000000000m,
                        Revenue = 60922000000m,
                        FreeCashFlow = 27020000000m,
                        RevenueGrowth = 125.9m,
                        EarningsGrowth = 288.5m,
                        DividendYield = 0.03m,
                        DividendPerShare = 0.16m,
                        PE = 68.2m,
                        PB = 52.8m,
                        ROE = 98.3m,
                        DebtToEquity = 35.6m,
                        LastUpdated = DateTime.UtcNow
                    }
                }
            }
        };

        return portfolio;
    }
}
