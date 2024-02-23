using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestProject1.Modals;

namespace TestProject1.Pages;

public class HomePage(IWebDriver driver) : AbstactPage(driver)
{
    [FindsBy(How = How.XPath, Using = "//h5[contains(text(), 'Elements')]")]
    private readonly IWebElement _elements;

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