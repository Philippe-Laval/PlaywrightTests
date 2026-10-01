# information

Tests sur web et mobile
https://www.browserstack.com/

## Tools

https://playwright.dev/
https://playwright.dev/dotnet/
https://playwright.dev/dotnet/docs/intro

Writing tests
https://playwright.dev/dotnet/docs/writing-tests


### Playwright Test
```
npm init playwright@latest
```

### Playwright CLI
Token-efficient browser automation for coding agents like Claude Code and GitHub Copilot. Skill-based workflows without large context overhead.

```
npm i -g @playwright/cli@latest
```

### Playwright MCP
Model Context Protocol server that gives AI agents full browser control through structured accessibility snapshots.

```
npx @playwright/mcp@latest
```


### Installer l'extension "Playwright Test for VSCode".

If you don't have the Playwright NPM package installed in your project, or if you are starting with a new testing project, the "Install Playwright" action from the command panel will help you get started.

install playwright


Inside that directory, you can run several commands:

  npx playwright test
    Runs the end-to-end tests.

  npx playwright test --ui
    Starts the interactive UI mode.

  npx playwright test --project=chromium
    Runs the tests only on Desktop Chrome.

  npx playwright test example
    Runs the tests in a specific file.

  npx playwright test --debug
    Runs the tests in debug mode.

  npx playwright codegen
    Auto generate tests with Codegen.


## Articles

### Test d’applications web avec le playwright de Microsoft (12 sur 12) | Tests logiciels automatisés
Série de présentation sur le test de logiciels

https://learn.microsoft.com/fr-fr/shows/visual-studio-toolbox/web-application-testing-with-microsofts-playwright-12-of-12-automated-software-testing

### Playwright with .NET. What? Is it useful?
https://medium.com/@dneprokos/playwright-with-net-what-is-it-useful-bafc85898b5

```
dotnet new nunit -n PlaywrightTestsWithDotNet
cd PlaywrightTestsWithDotNet
dotnet add package Microsoft.Playwright.NUnit
dotnet build
pwsh bin/Debug/net10.0/playwright.ps1 install
dotnet test -- NUnit.NumberOfTestWorkers=5

dotnet test -- settings:chromium.runsettings
dotnet test — settings:firefox.runsettings
dotnet test — settings:webkit.runsettings
```

Des exemples de run settings

Des exemple de test d'api



https://blog.promptly.mt/mcp-server-csharp/

https://blog.promptly.mt/copilot-desktop-mcp-workflow/

https://blog.promptly.mt/playwright-dotnet-mcp/

```
dotnet new nunit -n MyApp.E2E
cd MyApp.E2E
dotnet add package Microsoft.Playwright.NUnit
dotnet build
pwsh ./bin/Debug/net10.0/playwright.ps1 install
```

There's now a better way to author tests than recording your own mouse.

```
playwright codegen https://localhost:5001 --target csharp
```

## The Playwright MCP Server: Give Your AI Assistant Eyes and Hands
the Playwright MCP server works on accessibility snapshots, not screenshots.
When your agent calls browser_snapshot, it gets back the page's accessibility tree:
a structured, textual representation of every role, label, and state on the page. 

it needs Node.js 18+
```
npx @playwright/mcp@latest
```

For VS Code with Copilot in agent mode
```
{
  "mcpServers": {
    "playwright": {
      "command": "npx",
      "args": ["@playwright/mcp@latest"]
    }
  }
} 
```

```
claude mcp add playwright npx @playwright/mcp@latest
```

Once connected, the agent gets a serious tool surface: browser_navigate, browser_click, browser_type, browser_fill_form, browser_evaluate, browser_console_messages, browser_network_requests, browser_tabs, browser_wait_for, and browser_take_screenshot.Basically everything you'd do in DevTools, exposed as callable tools.

A few config flags worth knowing before you need them:

* --headless for no visible browser window (CI, or you just don't want the flicker)
* --browser to pick chromium, firefox, or webkit
* --isolated for an in-memory session; the default is a persistent profile, which keeps cookies and logins between runs
* --storage-state to load a saved auth state so the agent starts logged in
* --test-id-attribute to match your data - testid convention
* --device, --viewport-size, and --caps for device emulation, window dimensions, and extras like vision, PDF, or devtools

The --storage-state flag alone saves enormous friction. Export your logged-in state once from a Playwright test, and every agent session starts past the login wall.


"Open my app at https://localhost:5001 and write a Playwright test for the checkout flow."

# Actions

https://playwright.dev/dotnet/docs/writing-tests

Action	Description
* Locator.CheckAsync()	Check the input checkbox
* Locator.ClickAsync()	Click the element
* Locator.UncheckAsync()	Uncheck the input checkbox
* Locator.HoverAsync()	Hover mouse over the element
* Locator.FillAsync()	Fill the form field, input text
* Locator.FocusAsync()	Focus the element
* Locator.PressAsync()	Press single key
* Locator.SetInputFilesAsync()	Pick files to upload
* Locator.SelectOptionAsync()	Select option in the drop down


Assertion	Description
Expect(Locator).ToBeCheckedAsync()	Checkbox is checked
Expect(Locator).ToBeEnabledAsync()	Control is enabled
Expect(Locator).ToBeVisibleAsync()	Element is visible
Expect(Locator).ToContainTextAsync()	Element contains text
Expect(Locator).ToHaveAttributeAsync()	Element has attribute
Expect(Locator).ToHaveCountAsync()	List of elements has given length
Expect(Locator).ToHaveTextAsync()	Element matches text
Expect(Locator).ToHaveValueAsync()	Input element has value
Expect(Page).ToHaveTitleAsync()	Page has title
Expect(Page).ToHaveURLAsync()	Page has URL


[TestInitialize]
public async Task TestInitialize()
{
    await Page.GotoAsync("https://playwright.dev");
}

https://playwright.dev/dotnet/docs/codegen-intro

```
pwsh bin/Debug/net10.0/playwright.ps1 codegen https://localhost:5001/
```


https://playwright.dev/dotnet/docs/running-tests

```
dotnet test

$env:HEADED="1"
$env:BROWSER="webkit"
dotnet test

dotnet test -- Playwright.BrowserName=webkit

dotnet test --settings:chromium.runsettings
dotnet test --settings:firefox.runsettings
dotnet test --settings:webkit.runsettings

dotnet test --filter "ExampleTest"
dotnet test -- MSTest.Parallelize.Workers=5
```

Lancer les tests en mode debug
```
$env:PWDEBUG=1
dotnet test
```

https://playwright.dev/dotnet/docs/trace-viewer-intro

```
pwsh bin/Debug/net10.0/playwright.ps1 show-trace bin/Debug/net10.0/playwright-traces/PlaywrightTests.ExampleTest.MyTest.zip
```

https://playwright.dev/dotnet/docs/ci-intro

https://playwright.dev/dotnet/docs/test-runners

ExecutionScope.ClassLevel
Running tests in parallel at the method level (ExecutionScope.MethodLevel) is not supported

```
dotnet test --settings:.runsettings -- MSTest.Parallelize.Workers=4
```

On peut créer un fichier ".runsettings" avec les paramètres de configuration pour Playwright. 
Par exemple, le fichier "chromium.runsettings" peut contenir les paramètres suivants :
```
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <Playwright>
    <BrowserName>chromium</BrowserName>
    <LaunchOptions>
      <Headless>false</Headless>
      <Channel>msedge</Channel>
    </LaunchOptions>
  </Playwright>
</RunSettings>
```

On peut passer les paramètres de configuration directement dans la ligne de commande :
```
dotnet test -- Playwright.BrowserName=chromium Playwright.LaunchOptions.Headless=false Playwright.LaunchOptions.Channel=msedge
```

