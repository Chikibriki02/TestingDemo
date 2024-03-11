// Ignore Spelling: App

using BoDi;
using FluentAssertions.Common;
using Gherkin.Ast;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Runtime;
using TechTalk.SpecFlow;
using TestProject1.Modals;
using TestProject1.Pages;
using TestContext = TestProject1.Context.TestContext;

namespace TestProject1.Hooks
{
    [Binding]
    public static class Hooks
    {
        public static AppSettings AppSettings { get; set; }

        [BeforeTestRun]
        public static void BeforeScenario(IObjectContainer container)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

             AppSettings = configuration.Get<AppSettings>();
        }

        [Scope(Tag = "UI")]
        [BeforeFeature]
        public static void Setup(IObjectContainer container)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--force-device-scale-factor=0.85");

            if (AppSettings.Headless)
                chromeOptions.AddArgument("--headless");

            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            var driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();

            var context = new TestContext
            {
                Driver = driver,
                HomePage = new HomePage(driver),
                TestPage = new TestPage(driver),
                Cookies = new Cookies(driver)
            };

            container.RegisterInstanceAs(context);
        }

        [Scope(Tag = "UI")]
        [BeforeScenario]
        public static void Scenario(TestContext context)
        {
            try
            {
                IAlert alert = context.Driver.SwitchTo().Alert();
                alert.Dismiss();
            }
            catch (NoAlertPresentException)
            {}

            context.Driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        [Scope(Tag = "UI")]
        [AfterFeature]
        public static void TearDown(IObjectContainer container)
        {
            var seleniumContext = container.Resolve<TestContext>();
            seleniumContext.Driver.Quit();
        }
    }
}