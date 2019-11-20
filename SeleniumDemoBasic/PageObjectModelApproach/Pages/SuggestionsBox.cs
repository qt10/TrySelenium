using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SuggestionsBox: PageComponent
    {
        private By _suggestionLocator = By.CssSelector("ul.ui-autocomplete > li.ui-menu-item");

        public SuggestionsBox(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IReadOnlyCollection<IWebElement> _rows;

        public List<string> GetSuggestions()
        {
            return _rows.Select(i => i.Text).ToList();
        }
       
        public override void Initialize()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
            _rows = wait.Until(d =>
            {
                var elements = d.FindElements(_suggestionLocator);

                if (elements.Count == 0 || elements.All(i => !i.Displayed))
                    return null;

                return elements;
            });
        }

    }
}