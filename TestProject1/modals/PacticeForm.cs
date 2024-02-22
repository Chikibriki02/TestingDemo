using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestProject1.Modals;

public class PacticeForm : AbstactElement
{
    public PacticeForm(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
    {
        PageFactory.InitElements(driver, this);
        _inputFields = new Dictionary<string, IWebElement>
        {
            { "First Name", _firstNameInput },
            { "Last Name", _lastNameInput },
            { "Email", _emailInput },
            { "Mobile", _numberInput },
            { "Date Of Birth", _birthInput }
        };
    }

    private Dictionary<string, IWebElement> _inputFields;
        
    [FindsBy(How = How.Id, Using = "firstName")]
    private IWebElement _firstNameInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "lastName")]
    private IWebElement _lastNameInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "userEmail")]
    private IWebElement _emailInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "userNumber")]
    private IWebElement _numberInput { get; set; }
    
    [FindsBy(How = How.Id, Using = "dateOfBirthInput")]
    private IWebElement _birthInput { get; set; }
    
    [FindsBy(How = How.CssSelector, Using = "[class*=\"custom-control custom-radio custom-control-inline\"]")]
    private IList<IWebElement> _genderButtons { get; set; } 
    
    [FindsBy(How = How.CssSelector, Using = "[class*=\"custom-control custom-checkbox\"]")]
    private IList<IWebElement> _hobbiesButtons { get; set; }
    
    [FindsBy(How = How.CssSelector, Using = ".subjects-auto-complete__input input[type='text']")]
    private IWebElement _subjectInputDropdown { get; set; }
    
    [FindsBy(How = How.Id, Using = "uploadPicture")]
    private IWebElement _imageUpload { get; set; }
    
    [FindsBy(How = How.Id, Using = "submit")]
    private IWebElement _submitButton { get; set; }
    
    private SubjectInputDropdown _subjectDropdown { get; set; }

    public void SelectSubject(string subjectName)
    {
        _subjectInputDropdown.SendKeys(subjectName);
        _subjectDropdown = new SubjectInputDropdown(driver, this.parentElement);
        _subjectDropdown.SelectSubjectValue(subjectName);
    }
    
    public void ClickSubmit()=> _submitButton.Click();
    public void SetGender(string gender) =>_genderButtons.First(x=>x.Text == gender).Click();

    private class SubjectInputDropdown : AbstactElement
    {
        public SubjectInputDropdown(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }

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
        _imageUpload.SendKeys(imageRoute);
    }
}