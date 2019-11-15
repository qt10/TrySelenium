//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using System;
//using Xunit;

//namespace SeleniumDemoBasic
//{
//    public class HomeUITests
//    {
//        [Fact]
//        public void OpenMainPage_WhenExecuted_ReturnsMainPage()
//        {
//            var driver = new InternetExplorerDriver();

//            driver.Navigate()
//                .GoToUrl("http://localhost:5001/");

//            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);

//            var menu = driver.FindElement(By.XPath("/html/body/div[1]"));
//            var header = driver.FindElement(By.CssSelector("h1"));
//            var banner = driver.FindElement(By.CssSelector("img[src*='home-showcase.png']"));
//            var albumList = driver.FindElement(By.Id("album-list"));

//            Assert.Contains("Music Store", driver.Title);
//            Assert.True(menu.Displayed);
//            Assert.True(header.Displayed);
//            Assert.True(banner.Displayed);
//            Assert.True(albumList.Displayed);

//            driver.Quit();
//            driver.Dispose();
//        }
//}
