using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SearchResult
    {
        private IWebElement _resultHeader => _element.FindElement(By.CssSelector("h3 a"));
        private IWebElement _resultText => _element.FindElement(By.CssSelector("span.st"));

        private IWebElement _element;
        
        public SearchResult(IWebElement element)
        {
            _element = element;
        }

        public string GetResultHeader()
        {
            return _resultHeader.Text;
        }

        public string GetResultText()
        {
            return _resultText.Text;
        }
    }

    public class SearchResults : PageComponent
    {
        private IReadOnlyCollection<IWebElement> _results => _driver.FindElements(By.ClassName("g"));
        public SearchResults(IWebDriver driver) : base(driver)
        {
        }
        public List<SearchResult> Get()
        {
            return _results.Select(i => new SearchResult(i)).ToList();
        }
    }
}
