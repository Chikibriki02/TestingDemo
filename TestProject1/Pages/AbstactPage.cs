using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages;

public abstract class AbstractPage
{
    protected IWebDriver Driver;

    protected AbstractPage(IWebDriver driver)
    {
        this.Driver = driver;
        PageFactory.InitElements(driver, this);
    }
}