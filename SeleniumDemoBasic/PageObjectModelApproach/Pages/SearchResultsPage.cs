using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SearchResultsPage: Page
    {
        private readonly By SearchResultLocator = By.ClassName("o-product-list__item");
        private ReadOnlyCollection<IWebElement> _searchResults { get; set; }
        private SearchBar _searchBar { get; set; }        

        public SearchResultsPage(IWebDriver driver, string query) : base(driver)
        {
        }
       
        public SearchResultsPage Navigate()
        {
            GoTo();
            return this;
        }

        public override void Initialize()
        {
            _searchBar = new SearchBar(_driver);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _searchResults = wait.Until(d =>
            {
                var elements = d.FindElements(SearchResultLocator);
                if (elements.Count == 0)
                {
                    return null;
                }
                return elements;
            });
            _searchBar.Initialize();
        }

        public List<string> GetSearchResults()
        {
            return _searchResults.Select(el => el.Text).ToList();
        }
    }
}
