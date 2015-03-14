namespace bitsprint.Testing.Automation.Selenium
{
    using System;
    using System.Configuration;
    using System.Diagnostics.Contracts;

    using bitsprint.Testing.Automation.Selenium.Enumerations;

    using OpenQA.Selenium;

    using TechTalk.SpecFlow;

    [Binding]
    public class WebBrowser
    {
        public static IWebDriver Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    var driver = (WebDriverEnum)Enum.Parse(typeof(WebDriverEnum), ConfigurationManager.AppSettings["TargetBrowser"]);
                    var driverLocation = ConfigurationManager.AppSettings["WebDriverLocation"];

                    ScenarioContext.Current["browser"] = WebDriverFactory.Create(driver, driverLocation);
                }

                return (IWebDriver)ScenarioContext.Current["browser"];
            }
        }

        [BeforeStep()]
        protected void BeforeStep()
        {
            Contract.EnsuresOnThrow<Exception>(Close());
        }

        [AfterScenario()]
        [AfterTestRun()]
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public static bool Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
            {
                Current.Quit();
                Current.Dispose();
            }

            return true;
        }
    }
}
