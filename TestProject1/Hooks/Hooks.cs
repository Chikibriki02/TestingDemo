using BoDi;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestProject1.Modals;
using TestProject1.Pages;
using TestContext = TestProject1.Context.TestContext;

[Binding]
public static class Hooks
{
    
    [BeforeFeature]
    public static void Setup(IObjectContainer _container)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--force-device-scale-factor=0.85");
        //chromeOptions.AddArgument("--headless");
        chromeOptions.AddArgument("--window-size=1920,1080");
        chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
        var driver = new ChromeDriver(chromeOptions);
        driver.Manage().Window.Maximize();

        var seleniumContext = new TestContext
        {
            Driver = driver,
            HomePage = new HomePage(driver),
            TestPage = new TestPage(driver),
            Cookies = new Cookies(driver)
        };

        _container.RegisterInstanceAs(seleniumContext);
    }

    [BeforeScenario]
    public static void Scenario(TestContext context)
    {
        context.Driver.SwitchTo().NewWindow(WindowType.Tab);
    }

    [AfterFeature]
    public static void TearDown(IObjectContainer _container)
    {
        var seleniumContext = _container.Resolve<TestContext>();
        seleniumContext.Driver.Quit();
    }
}