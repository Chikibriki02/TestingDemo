using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestProject1.Modals;

namespace TestProject1.Pages;

public class HomePage(IWebDriver driver) : AbstractPage(driver)
{
    public IWebElement _elements => driver.FindElement(By.XPath("//h5[contains(text(), 'Elements')]"));

}