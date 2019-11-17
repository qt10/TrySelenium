using OpenQA.Selenium;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public class SearchBar : PageComponent
    {
        public IWebElement _searchInput;
        public IWebElement _btn;

        public SearchBar(IWebDriver webDriver, By parentBy = null) : base(webDriver, parentBy)
        {           
        }

        public override void Initialize()
        {
            _searchInput = _parent.FindElement(By.Id("searchbox"));
            _btn = _parent.FindElement(By.Id("searchButon"));
        }

        public void SearchFor(string query, bool finalize = true)
        {
            _searchInput.SendKeys(query);
            if (finalize)
            {
                _searchInput.SendKeys(Keys.Enter);
            }
        }
    }
}