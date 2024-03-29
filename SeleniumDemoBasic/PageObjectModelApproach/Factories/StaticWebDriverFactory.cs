﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using SeleniumDemoBasic.PageObjectModelApproach.FeatureTests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Factories
{
    public enum WindowSize
    {
        Hd,
        Fhd,
        Maximise,
        Unchanged
    }

    public static class StaticWebDriverFactory
    {
        private static string DriverPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static IWebDriver GetLocalWebDriver(Browser browser, bool headless = false)
        {
            if (headless && !(browser == Browser.Chrome || browser == Browser.Firefox))
            {
                throw new ArgumentException($"Headless mode is not currently supported for {browser}.");
            }
            switch (browser)
            {
                case Browser.Firefox:
                    return GetLocalWebDriver(StaticDriverOptionsFactory.GetFirefoxOptions(headless));

                case Browser.Chrome:
                    return GetLocalWebDriver(StaticDriverOptionsFactory.GetChromeOptions(headless));

                case Browser.IE:
                    return GetLocalWebDriver(StaticDriverOptionsFactory.GetInternetExplorerOptions());

                case Browser.Edge:
                    return GetLocalWebDriver(StaticDriverOptionsFactory.GetEdgeOptions());

                case Browser.Safari:
                    return GetLocalWebDriver(StaticDriverOptionsFactory.GetSafariOptions());

                default:
                    throw new PlatformNotSupportedException($"{browser} is not currently supported.");
            }
        }

        public static IWebDriver GetLocalWebDriver(ChromeOptions options, WindowSize windowSize = WindowSize.Hd)
        {
            IWebDriver driver = new ChromeDriver(DriverPath, options);
            return SetWindowSize(driver, windowSize);
        }

        public static IWebDriver GetLocalWebDriver(FirefoxOptions options, WindowSize windowSize = WindowSize.Hd)
        {
            var geckoDriverDirectory = DriverPath;
            var geckoService = FirefoxDriverService.CreateDefaultService(geckoDriverDirectory);
            geckoService.Host = "::1";

            IWebDriver driver = new FirefoxDriver(geckoService, options);
            return SetWindowSize(driver, windowSize);
        }

        public static IWebDriver GetLocalWebDriver(EdgeOptions options, WindowSize windowSize = WindowSize.Hd)
        {
            if (!Platform.CurrentPlatform.IsPlatformType(PlatformType.WinNT))
            {
                throw new PlatformNotSupportedException("Microsoft Edge is only available on Microsoft Windows.");
            }

            IWebDriver driver = new EdgeDriver(options);
            return SetWindowSize(driver, windowSize);
        }


        public static IWebDriver GetLocalWebDriver(InternetExplorerOptions options, WindowSize windowSize = WindowSize.Hd)
        {
            if (!Platform.CurrentPlatform.IsPlatformType(PlatformType.WinNT))
            {
                throw new PlatformNotSupportedException("Microsoft Internet Explorer is only available on Microsoft Windows.");
            }

            IWebDriver driver = new InternetExplorerDriver(DriverPath, options);
            return SetWindowSize(driver, windowSize);
        }

        public static IWebDriver GetLocalWebDriver(SafariOptions options, WindowSize windowSize = WindowSize.Hd)
        {
            if (!Platform.CurrentPlatform.IsPlatformType(PlatformType.Mac))
            {
                throw new PlatformNotSupportedException("Safari is only available on Mac Os.");
            }

            // I suspect that the SafariDriver is already on the path as it is within the Safari executable.
            // I currently have no means to test this
            IWebDriver driver = new SafariDriver(options);
            return SetWindowSize(driver, windowSize);
        }

        public static IWebDriver GetRemoteWebDriver(
            DriverOptions options,
            Uri gridUrl,
            WindowSize windowSize = WindowSize.Hd)
        {
            IWebDriver driver = new RemoteWebDriver(gridUrl, options);
            return SetWindowSize(driver, windowSize);
        }

        public static IWebDriver GetRemoteWebDriver(
            Browser browser,
            Uri gridUrl,
            PlatformType platformType = PlatformType.Any,
            string proxy = null)
        {
            switch (browser)
            {
                case Browser.Firefox:
                    return GetRemoteWebDriver(StaticDriverOptionsFactory.GetFirefoxOptions(platformType, proxy), gridUrl);

                case Browser.Chrome:
                    return GetRemoteWebDriver(StaticDriverOptionsFactory.GetChromeOptions(platformType, proxy), gridUrl);

                case Browser.IE:
                    return GetRemoteWebDriver(StaticDriverOptionsFactory.GetInternetExplorerOptions(platformType), gridUrl);

                case Browser.Edge:
                    return GetRemoteWebDriver(StaticDriverOptionsFactory.GetEdgeOptions(platformType), gridUrl);

                case Browser.Safari:
                    return GetRemoteWebDriver(StaticDriverOptionsFactory.GetSafariOptions(platformType), gridUrl);

                default:
                    throw new PlatformNotSupportedException($"{browser} is not currently supported.");
            }
        }

        public static IWebDriver SetWindowSize(IWebDriver driver, WindowSize windowSize)
        {
            switch (windowSize)
            {
                case WindowSize.Unchanged:
                    return driver;

                case WindowSize.Maximise:
                    driver.Manage().Window.Maximize();
                    return driver;

                case WindowSize.Hd:
                    driver.Manage().Window.Position = Point.Empty;
                    driver.Manage().Window.Size = new Size(1366, 768);
                    return driver;

                case WindowSize.Fhd:
                    driver.Manage().Window.Position = Point.Empty;
                    driver.Manage().Window.Size = new Size(1920, 1080);
                    return driver;

                default:
                    return driver;
            }
        }
    }
}