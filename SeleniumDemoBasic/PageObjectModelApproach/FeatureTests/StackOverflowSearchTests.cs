using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemoBasic.PageObjectModelApproach.Pages;
using SeleniumDemoBasic.PageObjectModelApproach.Utils;
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
    public class StackOverflowSearchTests: IDisposable
    {
        private IWebDriver _driver;
        private readonly Browser _browser;

        public StackOverflowSearchTests(Browser browser)
        {
            _browser = browser;
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            _driver = StaticWebDriverFactory.GetRemoteWebDriver(_browser, new Uri("http://localhost:4444/wd/hub"));

            //_driver = StaticWebDriverFactory.GetLocalWebDriver(_browser, true);
        }

        [TestCase("Lord")]
        [TestCase("Gemmell")]
        public void Given_HomePage_When_UserClicksOnSearch_Then_TooltipIsShown(string query)
        {
            // Arrange
            var homePage = new HomePage(_driver);
            homePage.Navigate().Initialize();

            // Act
            homePage.SearchBar.SearchFor("Lord", false);
            homePage.SuggestionsBox.WaitTillLoaded();

            // Assert
            Assert.True(homePage.SuggestionsBox.IsVisible());
        }        

        [TestCase("Lord")]
        [TestCase("Gemmell")]
        public void Given_HomePage_When_UserSearchesFor_Then_NavigationIsDone(string query)
        {
            // Arrange
            var homePage = new HomePage(_driver);
            homePage.Navigate().Initialize();
            var searchResultsPage = new SearchResultsPage(_driver, query);

            // Act
            homePage.SearchBar.SearchFor(query);
            searchResultsPage.WaitTillLoaded();
            searchResultsPage.Initialize();

            // Assert
            Assert.AreNotEqual(searchResultsPage.Url, _driver.Url);
            Assert.IsNotEmpty(searchResultsPage.SearchResults);
        }


        //[TestCase("docker")]
        //[TestCase("selenium")]
        //public void Given_SearchResultsPage_When_NavigatedOn_Then_SearchResultsAreShown(string tag)
        //{
        //    // Arrange
        //    var resultsPage = new SearchResultsPage(_driver, $"questions/tagged/{tag}");

        //    // Act
        //    resultsPage.Navigate().Initialize();

        //    // Assert
        //    Assert.IsNotEmpty(resultsPage.SearchResults);
        //    Assert.That(resultsPage.SearchResults.All(i => i.GetTags().Contains(tag)));
        //}

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
