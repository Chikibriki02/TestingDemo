using TestProject1.Modals;
using TestProject1.Pages;
namespace TestProject1.Context;

public class TestContext
{
    public IWebDriver Driver { get; set; }
    public HomePage HomePage { get; set; }
    public TestPage TestPage { get; set; }
    public Cookies Cookies { get; set; }
}