using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public abstract class Page: BasePage
    {
        public Page(IWebDriver driver): base(driver)
        { 
        } 
        
        public virtual string Url { get; set; }        
        public virtual void Refresh()
        {
            _driver.Navigate().Refresh();
        }
        
        protected virtual void GoTo()
        {
            if (!string.IsNullOrEmpty(Url))
            {
                _driver.Navigate().GoToUrl(Url);
                Initialize();
            }
        }      
        
    }
}
