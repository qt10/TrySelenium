using OpenQA.Selenium;
using System;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public abstract class PageComponent: BasePage
    {
        protected IWebElement _self;

        public PageComponent(IWebDriver driver): base(driver)
        {

        } 
    }
}
