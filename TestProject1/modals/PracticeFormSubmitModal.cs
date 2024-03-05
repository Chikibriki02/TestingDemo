using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.modals
{
    public class PracticeFormSubmitModal(IWebDriver driver) : AbstractModals(driver)
    {
        public IWebElement FormModal => _driver.FindElement(By.ClassName("modal-content"));
    }
}
