namespace bitsprint.Testing.Automation.Selenium
{
    using System;
    using System.Collections.Generic;

    using bitsprint.Testing.Automation.Selenium.Enumerations;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.IE;

    public class WebDriverFactory
    {
        private static readonly Dictionary<WebDriverEnum, Func<string, IWebDriver>> WebDrivers = new Dictionary<WebDriverEnum, Func<string, IWebDriver>>(2)
            {
                { WebDriverEnum.Chrome, (driverLocation) => new ChromeDriver(driverLocation) },
                { WebDriverEnum.IE, (driverLocation) => new InternetExplorerDriver(driverLocation) } //,
                // { WebDriverEnum.Firefox, (driverLocation) => new FirefoxDriver(driverLocation) }
            };

        public static IWebDriver Create(WebDriverEnum driver, string driverLocation)
        {
            Func<string, IWebDriver> driverFunc;

            return WebDrivers.TryGetValue(driver, out driverFunc)
                ? driverFunc.Invoke(driverLocation)
                : WebDrivers[WebDriverEnum.Chrome].Invoke(driverLocation);
        }
    }
}
