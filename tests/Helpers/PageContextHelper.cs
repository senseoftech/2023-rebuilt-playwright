using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sot.Rebuild.AutomatedTests.Helpers;


public class PageContextHelper
{
    private IList<string> _ressources = new List<string>();
    private readonly IPage _page;
    private readonly TestContext _testContext;

    public PageContextHelper(
        IPage page, 
        TestContext testContext)
    {
        _page = page;
        _testContext = testContext;
    }

    public async Task TakeScreenshotAsync()
    {
        var fileName = $"{DateTime.UtcNow:yyyyMMdd-HHmmss-FFFFF}.png";

        await _page.ScreenshotAsync(new()
        {
            Path = fileName
        });

        _ressources.Add(fileName);
    }

    public async Task StopTracingAsync()
    {
        var fileName = "trace.zip";

        await _page.Context.Tracing.StopAsync(new()
        {
            Path = fileName
        });

        _ressources.Add(fileName);

        foreach (var resource in _ressources)
        {
            _testContext.AddResultFile(resource);
        }
    }

    public async Task StartTracingAsync()
    {
        await _page.Context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true,
        });
    }
}
