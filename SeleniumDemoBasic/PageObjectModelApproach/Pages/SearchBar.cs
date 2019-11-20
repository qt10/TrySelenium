using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SearchBar : PageComponent
    {
        private IWebElement _searchInput;
        private IWebElement _btn;

        public SearchBar(IWebDriver webDriver) : base(webDriver)
        {           
        }

        public override void Initialize()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _searchInput = wait.Until(d => d.FindElement(By.Id("searchbox")));
            _btn = wait.Until(d => d.FindElement(By.Id("searchButon")));
        }

        public void SearchFor(string query, bool finalize = true)
        {
            foreach (var letter in query)
                _searchInput.SendKeys(letter.ToString());

            if (finalize)
                _searchInput.SendKeys(Keys.Enter);
        }
    }
}