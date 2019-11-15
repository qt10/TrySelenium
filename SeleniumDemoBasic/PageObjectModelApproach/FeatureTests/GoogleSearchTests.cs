using OpenQA.Selenium.Chrome;
using SeleniumDemoBasic.PageObjectModelApproach.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace SeleniumDemoBasic.PageObjectModelApproach.FeatureTests
{

    [TestFixture(Browser.IE)]
    [TestFixture(Browser.Chrome)]
    [TestFixture(Browser.Firefox)]
    public class GoogleSearchTests
    {
        private IWebDriver _driver;
        private Browser _browser;

        public GoogleSearchTests(Browser browser)
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
        public void Given_HomePage_When_UserEntersValidKeyword_Then_SuggestionsShown(string query)
        {   
            // Arrange
            var homePage = new GoogleHomePage(_driver);
            homePage.GoTo();

            // Act
            homePage.GetSearch().SearchFor(query);
            var suggestions = homePage.GetSuggestions().GetTexts();

            // Assert
            Assert.Greater(suggestions.Count, 0);
            Assert.That(suggestions, Is.All.Contains(query));
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            if (_driver != null) 
                _driver.Quit();
        }
    }
}
