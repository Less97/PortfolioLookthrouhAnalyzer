using System.Net.Http.Json;
using PortfolioAnalyzer.Shared.Models;

namespace PortfolioAnalyzer.Web.Services;

public class PortfolioClient : IPortfolioClient
{
    private readonly HttpClient _httpClient;

    public PortfolioClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Portfolio?> GetPortfolioAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Portfolio>("api/portfolio");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching portfolio: {ex.Message}");
            return null;
        }
    }

    public async Task<PortfolioAnalytics?> GetAnalyticsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<PortfolioAnalytics>("api/analytics");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching analytics: {ex.Message}");
            return null;
        }
    }
}
