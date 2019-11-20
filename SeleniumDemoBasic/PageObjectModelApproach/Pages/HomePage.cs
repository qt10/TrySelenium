using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class HomePage : Page
    {
        private SearchBar _searchBar;
        private SuggestionsBox _suggestionsBox;

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://exlibris.ch/de/";

        public override void Initialize()
        {
            _searchBar = new SearchBar(_driver);
            _suggestionsBox = new SuggestionsBox(_driver);

            WaitTillLoaded();

            _searchBar.Initialize(); 
        }

        public void SearchFor(string query)
        {
            _searchBar.SearchFor(query, false);
        }

        public List<string> GetSuggestions()
        {
            _suggestionsBox.Initialize();
            return _suggestionsBox.GetSuggestions();
        }

        public HomePage Navigate()
        {
            GoTo();
            return this;
        }
    }
}