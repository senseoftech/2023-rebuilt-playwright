using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.Threading.Tasks;

namespace Sot.Rebuild.AutomatedTests.PageModels;

internal class HomePageModel
{
    private readonly IPage _page;
    private readonly PlaywrightTest _playwrightTest;

    public HomePageModel(
        IPage page,
        PlaywrightTest playwrightTest)
    {
        _page = page;
        _playwrightTest = playwrightTest;
    }

    public async Task GoToAsync()
    {
        await _page.GotoAsync("https://dev-rebuild-nantes.azurewebsites.net/");
        await _playwrightTest.Expect(_page).ToHaveTitleAsync("Playwright Demo - Rebuild");
    }
}
