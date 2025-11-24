# Portfolio Lookthrough Analyzer

A comprehensive portfolio analysis tool built with .NET 8, Blazor WebAssembly, and .NET Aspire. Analyze your investment portfolio with detailed fundamental data, sector allocation, performance attribution, and dividend tracking.

## Features

### 📊 Portfolio Analytics
- **Fundamental Analysis**: View aggregated revenue, free cash flow, and growth metrics weighted by position size
- **Performance Attribution**: Track top contributors and detractors to portfolio performance
- **Sector Allocation**: Visual breakdown of portfolio by sector with interactive charts
- **Dividend Tracking**: Analyze dividend income by position and overall yield

### 📈 Visualizations
- Interactive charts using Radzen Blazor Components
- Sector allocation pie charts
- Performance attribution bar charts
- Dividend contribution analysis with data grids
- Real-time portfolio metrics

### 🔧 Technical Features
- **Blazor WebAssembly**: Fast, client-side SPA with C#
- **MAUI-Ready**: Shared class library compatible with future MAUI mobile app
- **.NET Aspire**: Modern cloud-native orchestration and deployment
- **Mock Data Provider**: Sample portfolio data for testing and development
- **Alpha Vantage Integration**: Free fundamental data API (configurable)

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [.NET Aspire workload](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/setup-tooling)
- Visual Studio 2022 17.9+ or Visual Studio Code with C# Dev Kit
- (Optional) [Alpha Vantage API Key](https://www.alphavantage.co/support/#api-key) - Free tier: 500 requests/day

## Installation

### Install .NET Aspire

```bash
dotnet workload update
dotnet workload install aspire
```

### Clone and Build

```bash
git clone <your-repo-url>
cd PortfolioLookthrouhAnalyzer
dotnet restore
dotnet build
```

## Configuration

### Alpha Vantage API Key (Optional)

1. Sign up for a free API key at [Alpha Vantage](https://www.alphavantage.co/support/#api-key)
2. Add your API key to `src/PortfolioAnalyzer.Api/appsettings.Development.json`:

```json
{
  "AlphaVantage": {
    "ApiKey": "YOUR_API_KEY_HERE"
  }
}
```

> **Note**: The application works with mock data by default. Alpha Vantage integration is prepared but not required for initial testing.

## Running the Application

### Using .NET Aspire (Recommended)

```bash
cd src/PortfolioAnalyzer.AppHost
dotnet run
```

This will start:
- **API Service**: https://localhost:7000
- **Blazor WebAssembly**: https://localhost:7001
- **Aspire Dashboard**: https://localhost:15888 (for monitoring)

### Running Services Individually

**API:**
```bash
cd src/PortfolioAnalyzer.Api
dotnet run
```

**Blazor WebAssembly:**
```bash
cd src/PortfolioAnalyzer.Web
dotnet run
```

## Project Structure

```
PortfolioLookthrouhAnalyzer/
├── src/
│   ├── PortfolioAnalyzer.Shared/          # MAUI-compatible shared library
│   │   ├── Models/                         # Domain models (Portfolio, Position, etc.)
│   │   ├── Services/                       # Business logic (AnalyticsService)
│   │   └── Interfaces/                     # Service contracts
│   │
│   ├── PortfolioAnalyzer.Api/             # ASP.NET Core Web API
│   │   ├── Controllers/                    # API endpoints
│   │   └── Services/                       # Mock data providers
│   │
│   ├── PortfolioAnalyzer.Web/             # Blazor WebAssembly
│   │   ├── Pages/                          # Razor pages (Dashboard, Portfolio, Analytics)
│   │   ├── Components/                     # Reusable Blazor components
│   │   └── Services/                       # API clients
│   │
│   ├── PortfolioAnalyzer.AppHost/         # .NET Aspire orchestration
│   └── PortfolioAnalyzer.ServiceDefaults/ # Shared Aspire configuration
│
└── PortfolioAnalyzer.sln
```

## Roadmap

### Phase 1 (Current - MVP)
- [x] Core domain models
- [x] Mock data provider
- [x] Analytics engine (FCF, revenue, growth, sectors)
- [x] Blazor WebAssembly UI with charts
- [x] .NET Aspire orchestration
- [x] Alpha Vantage integration (prepared)

### Phase 2 (Next)
- [ ] CSV import functionality for Degiro/Interactive Brokers
- [ ] Real-time price updates
- [ ] Historical performance tracking
- [ ] User preferences and settings
- [ ] Multiple portfolio support

### Phase 3 (Future)
- [ ] MAUI mobile application
- [ ] Advanced analytics (Sharpe ratio, beta, correlation)
- [ ] Tax loss harvesting suggestions
- [ ] Rebalancing recommendations
- [ ] Cloud deployment to Google Cloud Run

## Google Cloud Deployment

The application is designed for deployment to Google Cloud using Cloud Run (serverless containers):

```bash
# Build and push API container
gcloud builds submit --tag gcr.io/PROJECT_ID/portfolio-api

# Deploy API
gcloud run deploy portfolio-api \
  --image gcr.io/PROJECT_ID/portfolio-api \
  --platform managed \
  --region us-central1 \
  --allow-unauthenticated

# Build and deploy Blazor WebAssembly to Cloud Storage + CDN
# (Static hosting for Blazor WASM)
```

> **Cost Optimization**: Cloud Run offers a generous free tier (2 million requests/month) and scales to zero when not in use.

## Technologies Used

- **.NET 8**: Latest LTS version of .NET
- **Blazor WebAssembly**: Client-side C# framework
- **.NET Aspire**: Cloud-native orchestration and observability
- **Radzen Blazor**: Beautiful, interactive charts and data grids
- **Alpha Vantage**: Free fundamental data API
- **Google Cloud Run**: Serverless container platform (target deployment)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License.

## Support

For issues or questions, please open an issue on GitHub.

---

Built with ❤️ using .NET and Blazor
