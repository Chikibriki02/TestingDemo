using SeleniumExtras.PageObjects;

namespace TestProject1.Modals;

public class Cookies
{
    private readonly IWebDriver _driver;
    public Cookies(IWebDriver driver)
    {
        this._driver = driver;
        PageFactory.InitElements(driver, this);
    }

    public IWebElement? Accept => _driver.FindElement(By.ClassName("fc-cta-consent"));
}