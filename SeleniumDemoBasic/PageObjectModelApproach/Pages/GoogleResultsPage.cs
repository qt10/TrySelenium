using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    class GoogleResultsPage : BasePage
    {
        private SearchResults _searchResults;

        public GoogleResultsPage(IWebDriver driver) : base(driver)
        {
        }        
        public string SearchQuery { get; set; }
        public override string Url => $"http://google.com/search?q={SearchQuery}";

        public List<SearchResult> GetSearchResults()
        {
            return _searchResults.Get();
        }

        protected override void Initialize()
        {
            _searchResults = new SearchResults(_driver);
        }
    }
}
