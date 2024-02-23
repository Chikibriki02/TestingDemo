using BoDi;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestProject1.Modals;
using TestProject1.Pages;
using TestContext = TestProject1.Context.TestContext;

[Binding]
public class Hooks
{
    private readonly IObjectContainer _container;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void Setup()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--force-device-scale-factor=0.85");
        chromeOptions.AddArgument("--headless");
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

        _container.RegisterInstanceAs<TestContext>(seleniumContext);
    }

    [AfterScenario]
    public void TearDown()
    {
        var seleniumContext = _container.Resolve<TestContext>();
        seleniumContext.Driver.Quit();
    }
}
