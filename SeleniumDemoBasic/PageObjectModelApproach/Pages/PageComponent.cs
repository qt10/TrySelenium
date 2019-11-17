using OpenQA.Selenium;
using System;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public abstract class PageComponent: BasePage
    {
        protected static readonly By RootBy = By.TagName("body");
        public static readonly TimeSpan MaxElementLoadTime = TimeSpan.FromSeconds(10);

        protected IWebElement _parent;
        protected IWebElement _self;

        public PageComponent(IWebDriver driver, By parentBy): base(driver)
        {
            _parent = _driver.FindElement(parentBy ?? RootBy);
        }       
    }
}
