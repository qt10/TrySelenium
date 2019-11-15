//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System;
//using Xunit;

//namespace SeleniumDemoBasic
//{
//    public class RegistrationUITests
//    {
//        [Fact]
//        public void OpenRegistrationPage_WhenExecuted_ReturnsMainPage()
//        {
//            var driver = new ChromeDriver();

//            driver.Navigate().GoToUrl("http://localhost:5001/Account/Register");

//            var username = driver.FindElement(By.Id("Email"));
//            var password = driver.FindElement(By.Id("Password"));
//            var confirmPassword = driver.FindElement(By.Id("ConfirmPassword"));
//            var registerButton = driver.FindElement(By.CssSelector("input[value='Register']"));

//            username.SendKeys("gordon.freeman@test.com");
//            password.SendKeys("simple");
//            confirmPassword.SendKeys("simple");
//            registerButton.Click();

//            var fluentWait = new DefaultWait<IWebDriver>(driver);
//            fluentWait.Timeout = TimeSpan.FromSeconds(5);
//            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
//            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
//            var searchResult = fluentWait.Until(x => x.FindElement(By.ClassName("validation-summary-errors")));

//            var validationError = driver.FindElement(By.ClassName("validation-summary-errors"));

//            Assert.Contains("Passwords must have at least one non alphanumeric character", validationError.Text);
//            Assert.Contains("Passwords must have at least one digit ('0'-'9')", validationError.Text);

//            driver.Quit();
//            driver.Dispose();
//        }
//    }
//}
