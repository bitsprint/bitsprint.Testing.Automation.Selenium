namespace bitsprint.Testing.Automation.Selenium.Components
{
    using System;
    using System.Configuration;

    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;
    using bitsprint.Testing.Automation.Selenium.Extensions;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class BaseComponent : IComponent
    {
        protected readonly int Timeout = int.Parse(ConfigurationManager.AppSettings["TimeoutSeconds"]);

        public BaseComponent(
            By byLocator,
            IWebDriver driver,
            IWebElement parentElement = null,
            IWebElement element = null)
        {
            this.ByLocator = byLocator;
            this.Driver = driver;
            this.ParentElement = parentElement;
            this.Element = element;
        }

        public By ByLocator { get; set; }

        public IWebDriver Driver { get; set; }

        public IWebElement Element { get; set; }

        public IWebElement ParentElement { get; set; }

        public IWebElement GetElement(IWebElement parentElement = null, bool scroll = true)
        {
            try
            {
                if (this.ParentElement == null)
                {
                    var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.Timeout));

                    this.Element = this.Element ?? wait.Until(_ => _.FindElement(this.ByLocator));
                }
                else
                {
                    this.Element = this.Element ?? this.ParentElement.FindElement(this.ByLocator);
                }

                if (scroll) this.Driver.ExecuteJavaScript(string.Format("window.scrollTo(0, {0});", this.Element.Location.Y));

                return this.Element;
            }
            catch (Exception)
            {
                this.Driver.Quit();
                Assert.Fail("Element not found");
                return null;
            }
        }

        public bool IsElementPresentAndDisplayed()
        {
            try
            {
                this.Element = this.Driver.FindElement(this.ByLocator);

                return this.Element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Hover()
        {
            this.GetElement().Hover();
        }
    }
}