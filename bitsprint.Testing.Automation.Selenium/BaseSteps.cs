namespace bitsprint.Testing.Automation.Selenium
{
    using System;
    using System.Configuration;
    using System.Diagnostics.Contracts;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        protected int Timeout = int.Parse(ConfigurationManager.AppSettings["TimeoutSeconds"]);


        protected object CurrentPage
        {
            get { return ScenarioContext.Current["CurrentPage"]; }
            set { ScenarioContext.Current["CurrentPage"] = value; }
        }

        [BeforeStep()]
        protected void BeforeStep()
        {
            Contract.EnsuresOnThrow<Exception>(this.TearDown()); // Use Code Contracts to ensure we can tidy up if a test fails
        }

        [AfterScenario()]
        protected void AfterStep()
        {
            WebBrowser.Current.Quit();
        }

        protected bool TearDown()
        {
            WebBrowser.Current.Quit();
            Assert.Fail("Test failed as a result of step being unable to complete");
            return false;
        }

        protected void ImplicitWait(int? timeInSeconds = null)
        {
            int secondsToWait = Timeout;
            if (timeInSeconds.HasValue)
            {
                secondsToWait = timeInSeconds.Value;
            }

            WebBrowser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(secondsToWait));
        }
    }
}
