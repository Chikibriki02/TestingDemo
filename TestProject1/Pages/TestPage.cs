using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.DefaultWaitHelpers;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestProject1.modals;
using TestProject1.Modals;

namespace TestProject1.Pages;

public class TestPage : AbstractPage
{
    public TestPage(IWebDriver driver) : base(driver)
    {
        _wait = new WebDriverWait(driver, _timeout);
    }

    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);
    private readonly WebDriverWait _wait;
    
    public IWebElement Text => Driver.FindElement(By.ClassName("col-md-6"));

    private IList<IWebElement> Categories => Driver.FindElements(By.ClassName("element-group"));

    private IWebElement Form => Driver.FindElement(By.ClassName("practice-form-wrapper"));
    
    private IWebElement OpenedCategoryTab => Driver.FindElement(By.XPath("//*[contains(@class, 'element-list collapse show')]/.."));
    
    private CategoryTab CategoryTab { get; set; }

    public PracticeForm PracticeForm =>
        new(Driver, _wait.Until(ExpectedConditions.ElementToBeClickable((By.ClassName("practice-form-wrapper")))));
        

    public PracticeFormSubmitModal PracticeFormSubmitModal => new (Driver);
    public AlertElement AlertPage => new(Driver, _wait.Until(ExpectedConditions.ElementToBeClickable((By.Id("javascriptAlertsWrapper")))));
    public void OpenCategory(string name)
    {
        OpenedCategoryTab.FindElement(By.ClassName("group-header")).Click();
        var t = Categories.Select(x => x.Text).ToList();
        CategoryTab = new CategoryTab(Driver,Categories.First(x => x.Text.Contains(name)));
        CategoryTab.OpenCategory();
    }

    public void OpenTab(string tabName)
    {
        CategoryTab.OpenTab(tabName);
    }
}