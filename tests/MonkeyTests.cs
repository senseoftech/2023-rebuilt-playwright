using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sot.Rebuild.AutomatedTests.Helpers;
using Sot.Rebuild.AutomatedTests.PageModels;
using System.Threading.Tasks;

namespace Sot.Rebuild.AutomatedTests;

[TestClass]
public class MonkeyTests : PageTest
{
    [TestMethod]
    public async Task Flow_Home_ToPage1_ToPlanning()
    {

        var context = new PageContextHelper(Page, this.TestContext);
        await context.StartTracingAsync();

        var homePage = new HomePageModel(Page, this);

        await homePage.GoToAsync();

        //await counterPage.ExpectCurrentValueAreAsync("0");

        await context.TakeScreenshotAsync();

        //await counterPage.ClickOnIncrematalButtonAsync();
        //await counterPage.ExpectCurrentValueAreAsync("1");

        await context.TakeScreenshotAsync();

        await context.StopTracingAsync();
    }
}
