using OpenQA.Selenium;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public abstract class BasePage: PageComponent
    {       
        public BasePage(IWebDriver driver): base(driver)
        { 
        } 
        
        public virtual string Url { get; set; }        
        public virtual void Refresh()
        {
            _driver.Navigate().Refresh();
        }
        
        public virtual void GoTo()
        {
            if (!string.IsNullOrEmpty(Url))
            {
                _driver.Navigate().GoToUrl(Url);
                Initialize();
            }
        }
        protected virtual void Initialize()
        {
        }
    }

    public abstract class PageComponent
    {
        protected readonly IWebDriver _driver;
        public PageComponent(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
