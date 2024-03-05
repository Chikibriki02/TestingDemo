using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Modals;

namespace TestProject1.modals
{
    public class AlertPage(IWebDriver driver, IWebElement parentElement) : AbstactElement(driver, parentElement)
    {
        public IWebElement AlelrtButton => parentElement.FindElement(By.Id("alertButton"));
        public IWebElement Alelrt5SecButton => parentElement.FindElement(By.Id("timerAlertButton"));
        public IWebElement AlelrtConfirmButton => parentElement.FindElement(By.Id("confirmButton"));
        public IWebElement AlelrtTextButton => parentElement.FindElement(By.Id("promtButton"));
        public IWebElement AlertResultText => parentElement.FindElement(By.Id("confirmResult"));
    }
}
