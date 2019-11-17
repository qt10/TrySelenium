using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SuggestionsBox: PageComponent
    {
        public SuggestionsBox(IWebDriver webDriver, By parentBy = null) : base(webDriver, parentBy)
        {
            _parent = _driver.FindElement(parentBy ?? RootBy);
        }

        private IReadOnlyCollection<IWebElement> _rows;
       
        public List<string> GetHints()
        {
            return _rows.Select(i => i.Text).ToList();
        }

        public bool IsVisible()
        {
            return _self.Displayed;
        }

        public override void WaitTillLoaded()
        {
            var wait = new WebDriverWait(_driver, MaxElementLoadTime);
            wait.Until(d => d.FindElements(By.ClassName("ui-menu-item")).Count > 0);
        }

        public override void Initialize()
        {
            _self = _driver.FindElement(By.ClassName("ui-autocomplete"));
            _rows = _self.FindElements(By.ClassName("ui-menu-item"));
        }

    }
}