namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using System;
    using System.Globalization;

    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class Link : BaseComponent, IClickable
    {
        public Link(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public void Click()
        {
            this.GetElement().Click();
        }

        public bool ClickAndConfirmDestination(string destination)
        {
            this.Click();

            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));

            return wait.Until(_ => _.Url.ToString(CultureInfo.InvariantCulture).Contains(destination));
        }
    }
}
