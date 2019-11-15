using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SearchComponent: PageComponent
    {
        private IWebElement _searchBox => _driver.FindElement(By.Name("q"));
        private IWebElement _searchButton => _driver.FindElement(By.Name("btnK"));

        public SearchComponent(IWebDriver driver): base(driver)
        {
        }
        
        public void ConfirmSearch()
        {
            _searchBox.SendKeys(Keys.Enter);
        }

        public void SearchFor(string searchQuery)
        {
            foreach (var letter in searchQuery)
                _searchBox.SendKeys(letter.ToString());
        }
    }
}
