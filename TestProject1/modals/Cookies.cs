using SeleniumExtras.PageObjects;

namespace TestProject1.Modals;

public class Cookies
{
    private IWebDriver driver;
    public Cookies(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.ClassName, Using = "fc-cta-consent")]
    public IWebElement Accept;
}