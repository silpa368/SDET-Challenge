
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
        => await _page.Locator("div#search").InnerTextAsync().ContinueWith(t => t.Result.Contains(text));

    public async Task ClickCareersAsync()
        => await _page.Locator("a:has-text('Careers')").First.ClickAsync();
}
