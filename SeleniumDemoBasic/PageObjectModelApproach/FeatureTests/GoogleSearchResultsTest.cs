using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumDemoBasic.PageObjectModelApproach.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.FeatureTests
{
    [TestFixture(Browser.IE)]
    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    public class GoogleSearchResultsTests
    {
        private IWebDriver _driver;
        private Browser _browser;

        public GoogleSearchResultsTests(Browser browser)
        {
            _browser = browser;
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            switch (_browser)
            {
                case Browser.IE:
                    _driver = new InternetExplorerDriver();
                    break;
                case Browser.Chrome:
                    _driver = new ChromeDriver();
                    break;
                case Browser.Firefox:

                    var geckoDriverDirectory = ".\\";
                    var geckoService = FirefoxDriverService.CreateDefaultService(geckoDriverDirectory);
                    geckoService.Host = "::1";

                    var firefoxOptions = new FirefoxOptions
                    {
                        AcceptInsecureCertificates = true
                    };

                    _driver = new FirefoxDriver(geckoService, firefoxOptions);
                    break;
            }
        }

        [TestCase("test")]
        [TestCase("selenium")]
        public void Given_ResultsPage_When_NavigatedTo_Then_ResultsDisplayed(string query)
        {
            // Arrange
            var resultsPage = new GoogleResultsPage(_driver);

            // Act
            resultsPage.SearchQuery = query;
            resultsPage.GoTo();

            // Assert
            var results = resultsPage.GetSearchResults();
            Assert.Greater(results.Count, 0);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            if (_driver != null)
                _driver.Quit();
        }
    }
}
