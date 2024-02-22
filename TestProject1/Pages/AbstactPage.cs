using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProject1.Pages;

public abstract class AbstactPage
{
    protected IWebDriver driver;
    
    protected AbstactPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
}