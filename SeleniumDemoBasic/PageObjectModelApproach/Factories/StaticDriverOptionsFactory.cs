﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace SeleniumDemoBasic.PageObjectModelApproach.Factories
{
    public static class StaticDriverOptionsFactory
    {
        public static ChromeOptions GetChromeOptions(PlatformType platformType = PlatformType.Any, string proxy = null)
        {
            return GetChromeOptions(false, platformType, proxy);
        }

        public static ChromeOptions GetChromeOptions(bool headless = false, PlatformType platformType = PlatformType.Any, string proxy = null)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("disable-infobars", "test-type");
            if (headless)
            {
                options.AddArgument("headless");
            }

            if (proxy != null)
            {
                options.Proxy = new Proxy()
                {
                    HttpProxy = proxy,
                    SslProxy = proxy
                };
            }

            SetPlatform(options, platformType);
            return options;
        }

        public static FirefoxOptions GetFirefoxOptions(PlatformType platformType = PlatformType.Any, string proxy = null)
        {
            return GetFirefoxOptions(false, platformType, proxy);
        }

        public static FirefoxOptions GetFirefoxOptions(bool headless = false, PlatformType platformType = PlatformType.Any, string proxy = null)
        {
            FirefoxOptions options = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            if (headless)
            {
                options.AddArgument("--headless");
            }

            if (proxy != null)
            {
                options.Proxy = new Proxy()
                {
                    HttpProxy = proxy,
                    SslProxy = proxy
                };
            };

            SetPlatform(options, platformType);
            return options;
        }

        public static EdgeOptions GetEdgeOptions(PlatformType platformType = PlatformType.Any)
        {
            EdgeOptions options = new EdgeOptions();
            SetPlatform(options, platformType);
            return options;
        }

        public static InternetExplorerOptions GetInternetExplorerOptions(PlatformType platformType = PlatformType.Any)
        {
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                EnablePersistentHover = true,
                IgnoreZoomLevel = true,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss
            };

            SetPlatform(options, platformType);
            return options;
        }

        public static SafariOptions GetSafariOptions(PlatformType platformType = PlatformType.Any)
        {
            SafariOptions options = new SafariOptions();
            SetPlatform(options, platformType);
            return options;
        }

        public static T SetPlatform<T>(T options, PlatformType platformType) where T : DriverOptions
        {
            switch (platformType)
            {
                case PlatformType.Any:
                    return options;

                case PlatformType.Windows:
                    options.PlatformName = "WINDOWS";
                    return options;

                case PlatformType.Linux:
                    options.PlatformName = "LINUX";
                    return options;

                case PlatformType.Mac:
                    options.PlatformName = "MAC";
                    return options;

                default:
                    return options;
            }
        }
    }
}
