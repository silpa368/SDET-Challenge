
using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UiTests.Pages;

public class SearchResultsPage
{
    private readonly IPage _page;

    public SearchResultsPage(IPage page)
    {
        _page = page;
    }

    public async Task<bool> ContainsTextAsync(string text)
    {
        // Wait for search results to load and check if text is present on the page
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        var pageContent = await _page.TextContentAsync("body");
        return pageContent?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false;
    }

    public async Task ClickCareersAsync()
        => await _page.Locator("a:has-text('Careers')").First.ClickAsync();
}
