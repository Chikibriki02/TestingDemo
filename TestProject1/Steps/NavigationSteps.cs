using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TestProject1.Modals;
using TestProject1.Pages;
using TestContext = TestProject1.Context.TestContext;

namespace TestProject1.Steps;

[Binding]
public class NavigationSteps(TestContext testContext)
{
    private IWebDriver Driver { get; set; } = testContext.Driver;
    private HomePage HomePage { get; set; } = testContext.HomePage;
    private TestPage TestPage { get; set; } = testContext.TestPage;
    private Cookies Cookies { get; set; } = testContext.Cookies;

    private readonly string _imageRoute = $"{AppDomain.CurrentDomain.BaseDirectory}Docs/Images/image.png";

    [Given(@"Open the page for testing")]
    public void GivenOpenThePageForTesting()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com");
    }
    
    [When(@"user clicks '(.*)' button")]
    [Given(@"user clicks '(.*)' button")]
    public void WhenUserClicksButton(string element)
    {
        HomePage.ClickOnButton(element);
    }

    [Then(@"text for testing is visible")]
    public void ThenTextForTestingIsVisible()
    {
        var actual = TestPage.Text.Text;
        Assert.That(actual, Is.EqualTo("Please select an item from left to start practice."));
    }

    [Given(@"user accepts cookies")]
    public void GivenUserAcceptsCookies()
    {
        try
        {
            Cookies.Accept.Click();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Куки не были отображены \n{e}");
        }
        
    }

    [Given(@"user selects '(.*)' category")]
    [When(@"user selects '(.*)' category")]
    public void WhenUserSelectsCategory(string categoryName)
    {
        TestPage.OpenCategory(categoryName);
    }

    [Given(@"user selects '(.*)' tab")]
    [When(@"user selects '(.*)' tab")]
    public void WhenUserSelectsTab(string tabName)
    {
        TestPage.OpenTab(tabName);
    }

    [When(@"user set '(.*)' to '(.*)' field in Form")]
    public void WhenUserSetLastNameFieldInForm(string value, string field)
    {
       TestPage.PracticeForm.SetField(value,field);
    }

    [When(@"user set Gender to '(.*)' in Form")]
    public void WhenUserSetGenderToInForm(string gender)
    {
        TestPage.PracticeForm.SetGender(gender);
    }

    [When(@"user fill '(.*)' to Subject Field in Form")]
    public void WhenUserFillToSubjectFieldInForm(string subject)
    {
        TestPage.PracticeForm.SelectSubject(subject);
    }

    [When(@"user click submit button")]
    public void WhenUserClickSubmitButton()
    {
        TestPage.PracticeForm.ClickSubmit();
    }

    [When(@"user upload an image in Form")]
    public void WhenUserUploadAnImageInForm()
    {
        TestPage.PracticeForm.UploadImage(_imageRoute);
    }
}