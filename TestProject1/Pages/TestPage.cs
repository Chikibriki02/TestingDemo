using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.DefaultWaitHelpers;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestProject1.Modals;

namespace TestProject1.Pages;

public class TestPage : AbstactPage
{
    public TestPage(IWebDriver driver) : base(driver)
    {
        wait = new WebDriverWait(driver, timeout);
    }

    private TimeSpan timeout = TimeSpan.FromSeconds(10);
    private WebDriverWait wait;
    
    [FindsBy(How = How.ClassName, Using = "col-md-6")]
    public IWebElement Text { get; set; }

    [FindsBy(How = How.ClassName,Using = "element-group")]
    private IList<IWebElement> categories;
    
    private IWebElement Form => driver.FindElement(By.ClassName("practice-form-wrapper"));
    
    private IWebElement OpenedCategoryTab => driver.FindElement(By.XPath("//*[contains(@class, 'element-list collapse show')]/.."));
    
    private CategoryTab CategoryTab { get; set; }

    public PacticeForm PacticeForm =>
        new PacticeForm(driver, wait.Until(ExpectedConditions.ElementToBeClickable((By.ClassName("practice-form-wrapper")))));

    public void OpenCategory(string name)
    {
        OpenedCategoryTab.FindElement(By.ClassName("group-header")).Click();
        var t = categories.Select(x => x.Text).ToList();
        CategoryTab = new CategoryTab(driver,categories.First(x => x.Text.Contains(name)));
        CategoryTab.OpenCategory();
    }

    public void OpenTab(string tabName)
    {
        CategoryTab.OpenTab(tabName);
    }
}