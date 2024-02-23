using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using TestProject1.Pages;

namespace TestProject1.Modals;

public class PracticeForm : AbstactElement
{
    public PracticeForm(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
    {
        PageFactory.InitElements(driver, this);
        _inputFields = new Dictionary<string, IWebElement>
        {
            { "First Name", FirstNameInput },
            { "Last Name", LastNameInput },
            { "Email", EmailInput },
            { "Mobile", NumberInput },
            { "Date Of Birth", BirthInput }
        };
    }

    private readonly Dictionary<string, IWebElement> _inputFields;
        
    [FindsBy(How = How.Id, Using = "firstName")]
    private IWebElement FirstNameInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "lastName")]
    private IWebElement LastNameInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "userEmail")]
    private IWebElement EmailInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "userNumber")]
    private IWebElement NumberInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "dateOfBirthInput")]
    private IWebElement BirthInput { get; set; }
    
    [FindsBy(How = How.CssSelector, Using = "[class*=\"custom-control custom-radio custom-control-inline\"]")]
    private IList<IWebElement> GenderButtons { get; set; } 
    
    [FindsBy(How = How.CssSelector, Using = "[class*=\"custom-control custom-checkbox\"]")]
    private IList<IWebElement> _hobbiesButtons { get; set; }
    
    [FindsBy(How = How.CssSelector, Using = ".subjects-auto-complete__input input[type='text']")]
    private IWebElement SubjectInputDropdown { get; set; }
    
    [FindsBy(How = How.Id, Using = "uploadPicture")]
    private IWebElement ImageUpload { get; set; }
    
    [FindsBy(How = How.Id, Using = "submit")]
    private IWebElement SubmitButton { get; set; }
    
    private SubjectInputDropdownList SubjectDropdown { get; set; }

    public void SelectSubject(string subjectName)
    {
        SubjectInputDropdown.SendKeys(subjectName);
        SubjectDropdown = new SubjectInputDropdownList(driver, this.parentElement);
        SubjectDropdown.SelectSubjectValue(subjectName);
    }

    public void ClickSubmit()
    {
        //Рекламное окно перекрывет кнопку Submit
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true); window.scrollBy(0, 100);", SubmitButton);
        SubmitButton.Click();
    }
    public void SetGender(string gender) => GenderButtons.First(x=>x.Text == gender).Click();

    private class SubjectInputDropdownList(IWebDriver driver, IWebElement parentElement) : AbstactElement(driver, parentElement)
    {
        private IList<IWebElement> _values => wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("[id^='react-select-2']")));

        public void SelectSubjectValue(string name) => _values.First(x=>x.Text == name).Click();
        
    }
    
    public void SetField(string value, string field)
    {
        if (_inputFields.TryGetValue(field, out var element))
        {
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(value);
        }
        else
            throw new Exception("fuck this shit");
    }

    public void UploadImage(string imageRoute)
    {
        ImageUpload.SendKeys(imageRoute);
    }
}