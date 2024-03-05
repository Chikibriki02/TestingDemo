using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.modals
{
    public abstract class AbstractModals

    {
        protected readonly IWebDriver _driver;
        protected AbstractModals(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
