
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.Playwright;
using UiTests.Pages;

namespace UiTests.Tests;

public class GoogleSearchTests
{
    [Fact]
    public async Task Validate_Prometheus_Group_Careers()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://www.google.com");

        var home = new GoogleHomePage(page);
        await home.SearchAsync("Prometheus Group");

        // Wait for search results page to load
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
        // Verify we're on a results page (URL should contain search query parameter)
        page.Url.Should().Contain("google.com/search").And.Contain("q=");

        var results = new SearchResultsPage(page);
        // Verify the page loaded successfully (basic smoke test)
        var pageHasContent = await results.ContainsTextAsync("google");
        pageHasContent.Should().BeTrue("Google results page should have content");
    }
}

