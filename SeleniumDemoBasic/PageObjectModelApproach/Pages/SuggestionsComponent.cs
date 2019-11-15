using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SuggestionsComponent
    {
        private IWebDriver _driver;
        private IReadOnlyCollection<IWebElement> _results => _driver.FindElements(By.CssSelector("div.suggestions-inner-container"));
        public SuggestionsComponent(IWebDriver driver)
        {
            _driver = driver;
        }
        public List<string> GetTexts()
        {
           var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
           wait.Until(x => _results.Any(i => i.Displayed));

           return _results
                .Where(i => i.Displayed)
                .Select(i => i.FindElement(By.TagName("span")).Text)
                .ToList();
        }
    }
}
