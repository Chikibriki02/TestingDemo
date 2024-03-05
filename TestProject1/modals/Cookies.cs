using SeleniumExtras.PageObjects;
using TestProject1.modals;

namespace TestProject1.Modals;

public class Cookies(IWebDriver driver) : AbstractModals(driver)
{
    public IWebElement? Accept => _driver.FindElement(By.ClassName("fc-cta-consent"));
}