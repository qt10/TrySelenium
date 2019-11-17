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
            var wait = new WebDriverWait(_driver, PageComponent.MaxElementLoadTime);
            wait.Until(d => ((IJavaScriptExecutor) d).ExecuteScript("return (typeof document !== 'undefined' ? document.readyState : 'notready')").Equals("complete"));
        }        
    }
}
