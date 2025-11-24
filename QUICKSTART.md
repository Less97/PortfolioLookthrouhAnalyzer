# Quick Start Guide

Get your Portfolio Analyzer up and running in 5 minutes!

## Step 1: Install Prerequisites

```bash
# Install .NET 8 SDK
# Download from: https://dotnet.microsoft.com/download/dotnet/8.0

# Install .NET Aspire workload
dotnet workload install aspire
```

## Step 2: Restore and Build

```bash
cd PortfolioLookthrouhAnalyzer
dotnet restore
dotnet build
```

## Step 3: Run with Aspire

```bash
cd src/PortfolioAnalyzer.AppHost
dotnet run
```

## Step 4: Open in Browser

The Aspire dashboard will automatically open, or navigate to:
- **Blazor App**: https://localhost:7001
- **API**: https://localhost:7000/swagger
- **Aspire Dashboard**: https://localhost:15888

## What You'll See

The application comes with **pre-loaded mock data** featuring a sample portfolio with 8 positions:

### Dashboard
- Portfolio value and total P&L
- Aggregated fundamentals (Revenue, FCF, Growth)
- Top contributors and detractors
- Dividend summary

### Portfolio Page
- Detailed position listing
- Cost basis vs. market value
- Individual position P&L

### Analytics Page
- Interactive sector allocation pie chart
- Dividend breakdown by position
- Performance attribution charts

## Next Steps

### Add Real Data (Optional)

1. **Get Alpha Vantage API Key**: https://www.alphavantage.co/support/#api-key (free)

2. **Add to configuration**:
   ```json
   // src/PortfolioAnalyzer.Api/appsettings.Development.json
   {
     "AlphaVantage": {
       "ApiKey": "YOUR_KEY_HERE"
     }
   }
   ```

3. **Update API service** in `src/PortfolioAnalyzer.Api/Program.cs`:
   ```csharp
   // Replace MockFundamentalDataService with AlphaVantageService
   builder.Services.AddSingleton<IFundamentalDataService, AlphaVantageService>();
   ```

### CSV Import (Coming Soon)

CSV import for Degiro/Interactive Brokers portfolios is prepared but not yet implemented. The interface and controller endpoints are ready.

## Troubleshooting

### Port Already in Use
If ports 7000/7001 are in use, edit `src/PortfolioAnalyzer.AppHost/Program.cs` to change ports.

### Build Errors
```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build
```

### Aspire Dashboard Not Opening
Manually navigate to: https://localhost:15888

## Architecture Overview

```
┌─────────────────────────────────────────────┐
│         Blazor WebAssembly (WASM)          │
│         https://localhost:7001              │
│  ┌─────────────────────────────────────┐   │
│  │  Dashboard  │  Portfolio  │ Analytics│   │
│  └─────────────────────────────────────┘   │
└──────────────────┬──────────────────────────┘
                   │ HTTP/JSON API
┌──────────────────▼──────────────────────────┐
│           ASP.NET Core Web API              │
│           https://localhost:7000            │
│  ┌─────────────────────────────────────┐   │
│  │  Portfolio │ Analytics │ Fundamental│   │
│  │  Service   │  Engine   │ Data API   │   │
│  └─────────────────────────────────────┘   │
└─────────────────────────────────────────────┘
                   │
┌──────────────────▼──────────────────────────┐
│         Shared Library (MAUI-Ready)         │
│  Models │ Interfaces │ Business Logic       │
└─────────────────────────────────────────────┘
```

## Key Metrics Explained

### Weighted Fundamentals
All fundamental metrics (Revenue, FCF, Growth) are **weighted by position size** in your portfolio.

**Example**: If AAPL is 30% of your portfolio with 8% revenue growth, it contributes 2.4% to your portfolio's weighted revenue growth.

### Performance Attribution
Shows which positions contributed most (or least) to your overall portfolio return, both in absolute dollars and percentage terms.

### Sector Allocation
Groups your holdings by GICS sector to help you understand concentration risk.

## Development Tips

### Hot Reload
Blazor WebAssembly supports hot reload. Make changes to `.razor` files and see them instantly!

### API Testing
Swagger UI is available at: https://localhost:7000/swagger

### Add New Metrics
Edit `src/PortfolioAnalyzer.Shared/Services/AnalyticsService.cs` to add custom calculations.

### Customize Mock Data
Edit `src/PortfolioAnalyzer.Api/Services/MockPortfolioService.cs` to change the sample portfolio.

## Questions?

Check the [README.md](README.md) for full documentation or open an issue on GitHub.

---

Happy analyzing! 📊
