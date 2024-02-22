using OpenQA.Selenium.Support.UI;

namespace TestProject1.Hooks;

public class WaiterConditions
{
    public static IWebElement? WaitForElementClass(IWebDriver driver,IWebElement parent, By by, string className, TimeSpan timeout)
    {
        WebDriverWait wait = new WebDriverWait(driver, timeout);
        return wait.Until(drv =>
        {
            try
            {
                var element = parent.FindElement(by);
                var t = element.Text;
                if (element.GetAttribute("class").Split(' ').Contains(className))
                {
                    return element;
                }
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        });
    }
}