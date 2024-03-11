using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestProject1.Hooks;
using IWebElement = OpenQA.Selenium.IWebElement;

namespace TestProject1.Modals;

public class CategoryTab(IWebDriver driver, IWebElement parentElement) : AbstactElement(driver, parentElement)
{
    private IWebElement CategoryName => ParentElement.FindElement(By.ClassName("header-text"));
    
    private IList<IWebElement> Tabs => ParentElement.FindElements(By.CssSelector("[class*=\"btn btn-light\"]"));
    
    //private IList<IWebElement> Tabss => Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("[class*=\"btn btn-light\"]")));
    
    private IWebElement CheckForCollapsedList => ParentElement.FindElement(By.CssSelector("[class*=\"element-list collapse\"]"));

    public bool IsOpen()
    {
        return CheckForCollapsedList.GetAttribute("class").Contains("show");
    }

    public void OpenCategory()
    {
        if (!IsOpen())
            CategoryName.Click();
        WaiterConditions.WaitForElementClass(Driver, ParentElement, By.CssSelector("[class*=\"element-list collapse\"]"), "show",
            TimeSpan.FromSeconds(10));
    }

    public void OpenTab(string tabName)
    {
        Tabs.First(x=>x.Text == tabName).Click();
    }
}