
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

        var results = new SearchResultsPage(page);
        (await results.ContainsTextAsync("Prometheus Group")).Should().BeTrue();

        await results.ClickCareersAsync();
    }
}

