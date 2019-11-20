using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{

    public abstract class BasePage
    {
        protected readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public virtual void Initialize()
        {             
        }
        public virtual void WaitTillLoaded()
        {
        }
    }
}
