using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestProject1.Modals;

namespace TestProject1.Pages;

public class HomePage : AbstactPage
{
    [FindsBy(How = How.XPath, Using = "//h5[contains(text(), 'Elements')]")]
    private IWebElement _elements;
    
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

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