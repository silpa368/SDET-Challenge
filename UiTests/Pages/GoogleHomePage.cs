
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UiTests.Pages;

public class GoogleHomePage
{
    private readonly IPage _page;

    public GoogleHomePage(IPage page)
    {
        _page = page;
    }

    public async Task SearchAsync(string text)
    {
        await _page.FillAsync("textarea[name='q']", text);
        await _page.Keyboard.PressAsync("Enter");
    }
}
