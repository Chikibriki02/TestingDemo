using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.Xml.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestProject1.Modals;
using TestProject1.Pages;
using TestContext = TestProject1.Context.TestContext;
using OpenQA.Selenium.Support.UI;

namespace TestProject1.Steps;

[Binding]
public class NavigationSteps(TestContext testContext)
{
    private IWebDriver Driver { get; set; } = testContext.Driver;
    private HomePage HomePage { get; set; } = testContext.HomePage;
    private TestPage TestPage { get; set; } = testContext.TestPage;
    private Cookies Cookies { get; set; } = testContext.Cookies;

    private IAlert Alert {get; set; }

    private readonly string _imageRoute = $"{AppDomain.CurrentDomain.BaseDirectory}Docs/Images/image.png";
    private readonly string _expectedUserForm = "Thanks for submitting the form\r\nLabel Values\r\nStudent Name QWERTY YTREWQ\r\nStudent Email qwerty@gmail.com\r\nGender Male\r\nMobile 1234567890\r\nDate of Birth 19 June,2001\r\nSubjects English\r\nHobbies\r\nPicture image.png\r\nAddress\r\nState and City\r\nClose";

    private void ClickOnButton(string buttonName)
    {
        switch (buttonName)
        {
            case "Elements": HomePage._elements.Click(); break;
            case "Click Button to see alert": TestPage.AlertPage.AlelrtButton.Click(); break;
            case "On button click, alert will appear after 5 seconds": TestPage.AlertPage.Alelrt5SecButton.Click(); break;
            case "On button click, confirm box will appear": TestPage.AlertPage.AlelrtConfirmButton.Click(); break;
            case "On button click, prompt box will appear": TestPage.AlertPage.AlelrtTextButton.Click(); break;
            //case "qqqqqqqq": HomePage._elements.Click(); break;

            default: _: throw new Exception("No such button"); break;
        }
    }

    private void ClickOnAlertButton(string buttonName)
    {
        switch (buttonName)
        {
            case "Ok": Alert.Accept(); break;
            case "Cancel": Alert.Dismiss(); break;

            default: _: throw new Exception("No such button"); break;
        }
    }

    [Given(@"Open the page for testing")]
    public void GivenOpenThePageForTesting()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com");
    }

    [When(@"user clicks '(.*)' button")]
    [Given(@"user clicks '(.*)' button")]
    public void WhenUserClicksButton(string element)
    {
        ClickOnButton(element);
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
        TestPage.PracticeForm.SetField(value, field);
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

    [When(@"the user form is filled")]
    public void WhenTheUserFormIsFilled()
    {
        Assert.That(TestPage.PracticeFormSubmitModal.FormModal.Text, Is.EqualTo(_expectedUserForm));
    }

    [Then(@"alert is visible")]
    [When(@"alert is visible")]
    public void ThenAlertIsVisible()
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        Alert = wait.Until(drv =>
        {
            try
            {
                return drv.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return null;
            }
        });
        if (Alert != null)
            Assert.Pass("Alert is displayed");
        else
            Assert.Fail("Alert is not found in 10 seconds");
    }

    [When(@"User click to '([^']*)' alert")]
    public void WhenUserClickToAlert(string buttonName)
    {
        ClickOnAlertButton(buttonName);
    }

    [Then(@"user selected '([^']*)'")]
    public void ThenUserSelected(string expectedText)
    {
        Assert.That(TestPage.AlertPage.AlertResultText.Text, Is.EqualTo(expectedText));
    }

}