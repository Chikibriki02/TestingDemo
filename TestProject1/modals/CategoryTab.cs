using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestProject1.Hooks;
using IWebElement = OpenQA.Selenium.IWebElement;

namespace TestProject1.Modals;

public class CategoryTab
{
    private readonly IWebDriver driver;
    private readonly IWebElement parentElement;
    private TimeSpan timeout = TimeSpan.FromSeconds(10);
    private WebDriverWait wait;
    
    public CategoryTab(IWebDriver driver, IWebElement parentElement)
    {
        this.driver = driver;
        this.parentElement = parentElement;
        PageFactory.InitElements(driver, this);
        wait = new WebDriverWait(driver, timeout);
    }

    private IWebElement CategoryName => parentElement.FindElement(By.ClassName("header-text"));
    
    private IList<IWebElement> Tabs => parentElement.FindElements(By.CssSelector("[class*=\"btn btn-light\"]"));
    
    private IList<IWebElement> Tabss => wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("[class*=\"btn btn-light\"]")));
    
    private IWebElement CheckForCollapsedList => parentElement.FindElement(By.CssSelector("[class*=\"element-list collapse\"]"));

    public bool IsOpen()
    {
        return CheckForCollapsedList.GetAttribute("class").Contains("show");
    }

    public void OpenCategory()
    {
        if (!IsOpen())
            CategoryName.Click();
        WaiterConditions.WaitForElementClass(driver,parentElement,By.CssSelector("[class*=\"element-list collapse\"]"), "show",
            TimeSpan.FromSeconds(10));
    }

    public void OpenTab(string tabName)
    {
        Tabs.FirstOrDefault(x=>x.Text == tabName).Click();
    }
}