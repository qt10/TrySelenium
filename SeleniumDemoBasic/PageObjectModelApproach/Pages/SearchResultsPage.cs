using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SearchResultsPage: Page, INavigatable<SearchResultsPage>, IInitializable<SearchResultsPage>
    {
        public SearchResultsPage(IWebDriver driver, string query) : base(driver)
        {
            Url = $"https://exlibris.ch/de/suche/?q={query}&category=All&searchtype=ss&psort=&size=&p=1";
        }
        public SearchBar SearchBar { get; private set; }
        public List<SearchResult> SearchResults { get; private set; }
        
        public SearchResultsPage Navigate()
        {
            GoTo();
            return this;
        }

        public new SearchResultsPage Initialize()
        {
            SearchBar = new SearchBar(_driver);

            WaitTillLoaded();

            SearchResults = _driver.FindElements(By.ClassName("o-product-list__item"))
                .Select(i => new SearchResult(_driver, i))
                .ToList();

            SearchBar.Initialize();
            SearchResults.ForEach(i => i.Initialize());
            return this;
        }
    }
}
