using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestProject1.Modals;

namespace TestProject1.Pages;

public class HomePage(IWebDriver driver) : AbstractPage(driver)
{
    private readonly IWebElement _elements = driver.FindElement(By.XPath("//h5[contains(text(), 'Elements')]"));

    public void ClickOnButton(string name)
    {
        switch (name)
        {
            case "Elements" : _elements.Click(); break;
            
            default:
                return;
        }
    }
}