using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class GoogleHomePage: BasePage
    {
        private SuggestionsComponent _suggestions => new SuggestionsComponent(_driver);
        private SearchComponent _search => new SearchComponent(_driver);

        public GoogleHomePage(IWebDriver driver): 
            base(driver)
        {
        }
        public override string Url => "http://google.com";
       
        public SearchComponent GetSearch()
        {
            return _search;
        }

        public SuggestionsComponent GetSuggestions()
        {
            return _suggestions;
        }
    }
}
