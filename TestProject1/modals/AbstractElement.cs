using OpenQA.Selenium.Support.UI;

namespace TestProject1.Modals;

public abstract class AbstactElement
{
    protected readonly IWebDriver Driver;
    protected readonly IWebElement ParentElement;
    protected readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);
    protected readonly WebDriverWait Wait;

    protected AbstactElement(IWebDriver driver, IWebElement parentElement)
    {
        this.Driver = driver;
        this.ParentElement = parentElement;
        this.Wait = new WebDriverWait(driver, Timeout);
    }
}