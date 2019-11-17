using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SearchResult : PageComponent
    {
        private IWebElement _title;
        public SearchResult(IWebDriver driver, IWebElement self) : base(driver, null)
        {
            _self = self;
        }

        public string GetTitle()
        {
            return _title.Text;
        }

        public bool IsVisible()
        {
            return _self.Displayed;
        }

        public override void Initialize()
        {
            _title = _self.FindElement(By.ClassName("m-product-tile__title"));
        }
    }
}
