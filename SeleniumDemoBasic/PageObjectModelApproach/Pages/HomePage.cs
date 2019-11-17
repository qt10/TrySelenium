using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class HomePage : Page, IInitializable<HomePage>, INavigatable<HomePage>
    {
        public SearchBar SearchBar { get; private set; }
        public SuggestionsBox SuggestionsBox { get; private set; }

        public override string Url => "https://exlibris.ch";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public new HomePage Initialize()
        {
            SearchBar = new SearchBar(_driver);
            SuggestionsBox = new SuggestionsBox(_driver);

            WaitTillLoaded();

            SearchBar.Initialize();
            SuggestionsBox.Initialize();            
            return this;
        }
        
        public HomePage Navigate()
        {
            GoTo();
            return this;
        }

        public void WaitTillNavigatedFrom()
        {
            var wait = new WebDriverWait(_driver, PageComponent.MaxElementLoadTime);
            wait.Until(d => d.Url != Url && d.Url != $"{d.Url}/de");
            WaitTillLoaded();
        }
    }
}