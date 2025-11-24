using PortfolioAnalyzer.Shared.Interfaces;
using PortfolioAnalyzer.Shared.Models;
using System.Text.Json;

namespace PortfolioAnalyzer.Api.Services;

/// <summary>
/// Alpha Vantage API integration for fetching fundamental data
/// Free tier: 500 requests/day, 5 requests/minute
/// Sign up at: https://www.alphavantage.co/support/#api-key
/// </summary>
public class AlphaVantageService : IFundamentalDataService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AlphaVantageService> _logger;
    private readonly string? _apiKey;
    private const string BaseUrl = "https://www.alphavantage.co/query";

    public AlphaVantageService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<AlphaVantageService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _apiKey = configuration["AlphaVantage:ApiKey"];

        if (string.IsNullOrEmpty(_apiKey))
        {
            _logger.LogWarning("Alpha Vantage API key not configured. Set 'AlphaVantage:ApiKey' in configuration.");
        }
    }

    public async Task<FundamentalData?> GetFundamentalDataAsync(string symbol)
    {
        if (string.IsNullOrEmpty(_apiKey))
        {
            _logger.LogWarning("Alpha Vantage API key not configured. Returning null.");
            return null;
        }

        try
        {
            // Alpha Vantage OVERVIEW endpoint provides company fundamentals
            var url = $"{BaseUrl}?function=OVERVIEW&symbol={symbol}&apikey={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Alpha Vantage API request failed: {StatusCode}", response.StatusCode);
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(content);
            var root = jsonDoc.RootElement;

            // Check for API rate limit or error messages
            if (root.TryGetProperty("Note", out var note))
            {
                _logger.LogWarning("Alpha Vantage rate limit reached: {Note}", note.GetString());
                return null;
            }

            if (root.TryGetProperty("Error Message", out var error))
            {
                _logger.LogError("Alpha Vantage error: {Error}", error.GetString());
                return null;
            }

            return new FundamentalData
            {
                Symbol = symbol,
                MarketCap = ParseDecimal(root, "MarketCapitalization"),
                Revenue = ParseDecimal(root, "RevenueTTM"),
                FreeCashFlow = ParseDecimal(root, "OperatingCashflowTTM"),
                RevenueGrowth = ParseDecimal(root, "QuarterlyRevenueGrowthYOY") * 100,
                EarningsGrowth = ParseDecimal(root, "QuarterlyEarningsGrowthYOY") * 100,
                DividendYield = ParseDecimal(root, "DividendYield") * 100,
                DividendPerShare = ParseDecimal(root, "DividendPerShare"),
                PE = ParseDecimal(root, "PERatio"),
                PB = ParseDecimal(root, "PriceToBookRatio"),
                ROE = ParseDecimal(root, "ReturnOnEquityTTM") * 100,
                DebtToEquity = 0, // Not directly available in Overview
                LastUpdated = DateTime.UtcNow
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching fundamental data for {Symbol}", symbol);
            return null;
        }
    }

    public async Task<Dictionary<string, FundamentalData>> GetBulkFundamentalDataAsync(IEnumerable<string> symbols)
    {
        var result = new Dictionary<string, FundamentalData>();

        // Alpha Vantage free tier: 5 requests/minute
        // Add delay between requests to avoid rate limiting
        foreach (var symbol in symbols)
        {
            var data = await GetFundamentalDataAsync(symbol);
            if (data != null)
            {
                result[symbol] = data;
            }

            // Wait 12 seconds between requests (5 requests/minute = 1 request per 12 seconds)
            await Task.Delay(TimeSpan.FromSeconds(12));
        }

        return result;
    }

    private static decimal ParseDecimal(JsonElement element, string propertyName)
    {
        if (element.TryGetProperty(propertyName, out var prop) &&
            prop.ValueKind == JsonValueKind.String)
        {
            var value = prop.GetString();
            if (!string.IsNullOrEmpty(value) && decimal.TryParse(value, out var result))
            {
                return result;
            }
        }
        return 0;
    }
}
