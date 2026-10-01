# Playwright for .NET

La documentation de Playwright pour .NET est disponible à l'adresse suivante :
https://playwright.dev/dotnet/docs/intro
    
```
dotnet new mstest -n PlaywrightTests
<UseVSTest>true</UseVSTest> to PlaywrightTests.csproj
cd PlaywrightTests
dotnet add package Microsoft.Playwright.MSTest.v4
```

Il faut d'abord compiler le projet avant d'installer Playwright.

```
dotnet build
pwsh bin/Debug/net10.0/playwright.ps1 install
```
    
This command download files to  C:\Users\philippe.laval\AppData\Local\ms-playwright
* Chrome for Testing 153.0.8010.12
* Chrome Headless Shell
* Firefox 155.0
* Webkit 26.6
* FFmpeg v1011
* Winldd v1007

Lancer les tests avec la commande suivante :

```
dotnet test
``` 