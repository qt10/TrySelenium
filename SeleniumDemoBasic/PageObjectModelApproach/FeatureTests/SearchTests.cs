using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemoBasic.PageObjectModelApproach.Factories;
using SeleniumDemoBasic.PageObjectModelApproach.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.FeatureTests
{
    //[TestFixture(Browser.IE)]
    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    [Parallelizable]
    public class ExLibrisSearchTests : IDisposable
    {
        private IWebDriver _driver;
        private readonly Browser _browser;

        public ExLibrisSearchTests(Browser browser)
        {
            _browser = browser;
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            _driver = StaticWebDriverFactory.GetRemoteWebDriver(browser: _browser, gridUrl: new Uri("http://localhost:4444/wd/hub"), proxy: null);
            //_driver = StaticWebDriverFactory.GetLocalWebDriver(_browser, false);
        }

        [TestCase("Lord of the Rings")]
        [TestCase("David Gemmell")]
        public void Given_HomePage_When_UserClicksOnSearch_Then_SuggestionsAreShown(string query)
        {
            // Arrange
            var homePage = new HomePage(_driver);
            homePage.Navigate().Initialize();

            // Act
            homePage.SearchFor(query);
            var suggestions = homePage.GetSuggestions();

            // Assert
            Assert.IsNotEmpty(suggestions);
        }

        [TestCase("Lord")]
        [TestCase("Gemmell")]
        public void Given_HomePage_When_UserSearchesFor_Then_SearchResultsAreShown(string query)
        {
            // Arrange
            var homePage = new HomePage(_driver);
            homePage.Navigate().Initialize();
            var searchResultsPage = new SearchResultsPage(_driver, query);

            // Act
            homePage.SearchFor(query);
            searchResultsPage.WaitTillLoaded();
            searchResultsPage.Initialize();

            // Assert
            Assert.IsNotEmpty(searchResultsPage.GetSearchResults());
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
