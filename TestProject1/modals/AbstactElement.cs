using OpenQA.Selenium.Support.UI;

namespace TestProject1.Modals;

public abstract class AbstactElement
{
    protected readonly IWebDriver driver;
    protected readonly IWebElement parentElement;
    protected readonly TimeSpan timeout = TimeSpan.FromSeconds(10);
    protected readonly WebDriverWait wait;
    public AbstactElement(IWebDriver driver, IWebElement parentElement)
    {
        this.driver = driver;
        this.parentElement = parentElement;
        this.wait = new WebDriverWait(driver, timeout);
    }
}