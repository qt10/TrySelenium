using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SeleniumDemoBasic.Basic.FeatureTests
{
    public class SearchTests
    {
        public SearchTests()
        {
        }

        [Test]
        public void Given_HomePage_When_UserTypesSearchQuery_Then_SuggestionsAreShown()
        {
   
            using var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://exlibris.ch/de");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var searchInput = wait.Until(d => d.FindElement(By.Id("searchbox")));

            var query = "Mary Poppins";
            searchInput.SendKeys(query);

            var suggestionsLinks = wait.Until(d => 
            {
                var elements = d.FindElements(By.CssSelector(".ui-autocomplete > .ui-menu-item > a"));
                if (elements.Count(e => e.Displayed) == 0)
                {
                    return null;
                }
                return elements;
            });
            var suggestions = suggestionsLinks.Select(i => i.Text).ToList();

            Assert.IsNotEmpty(suggestions);
            Assert.That(suggestions.All(i => i.Contains(query)));
        }

        [Test]
        public void Given_HomePage_When_UserEntersSearchQuery_Then_NavigatedToResultsPage()
        {
            var driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var geckoService = FirefoxDriverService.CreateDefaultService(driverPath);
            geckoService.Host = "::1";

            using var driver = new FirefoxDriver(geckoService);

            // not recommended
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://exlibris.ch/de");

            var searchInput = driver.FindElement(By.Id("searchbox"));

            var query = "Mary Poppins";
            searchInput.SendKeys(query + Keys.Enter);

            var searchResults = driver.FindElements(By.ClassName("m-product-tile__title"));

            Assert.IsNotEmpty(searchResults);
        }

    }
}
