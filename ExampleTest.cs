using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlaywrightTests;

[TestClass]
public class ExampleTest : PageTest
{
    [TestInitialize]
    public async Task TestInitialize()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [TestCleanup]
    public async Task TestCleanup()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                Environment.CurrentDirectory,
                "playwright-traces",
                $"{TestContext.FullyQualifiedTestClassName}.{TestContext.TestName}.zip"
            )
        });
    }

    [TestMethod]
    public async Task Test_PlayWithBlazorDevExpress()
    {
        // Need to run the Blazor DevExpress application first, then run this test.
        await Page.GotoAsync("https://localhost:5001/");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter Count mouse clicks" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();
        await Page.GetByRole(AriaRole.Menuitem, new() { Name = "Weather" }).ClickAsync();
        await Page.GetByRole(AriaRole.Menuitem, new() { Name = "Counter" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).DblClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Back to Home" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Counter Count mouse clicks" }).ClickAsync();
    }

    [TestMethod]
    public async Task Test_ScreenshotAsync()
    {

        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(
                new() { Headless = false }
            );
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://playwright.dev/dotnet");
        await page.ScreenshotAsync(new() { Path = "screenshot.png" });
    }


    [TestMethod]
    public async Task HasTitle()
    {
        // Most of the tests will start by navigating the page to a URL
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [TestMethod]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Create a locator.
        //var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Click it.
        //await getStarted.ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" }))
            .ToBeVisibleAsync();
    }

    /// <summary>
    /// Override the default context options for the tests.
    /// We uses Light color scheme and a viewport size of 1920x1080.
    /// </summary>
    /// <returns></returns>
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            ColorScheme = ColorScheme.Light,
            ViewportSize = new()
            {
                Width = 1920,
                Height = 1080
            },
            BaseURL = "https://playwright.dev",
        };
    }
}
