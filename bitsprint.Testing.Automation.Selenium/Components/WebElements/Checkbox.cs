namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using System;

    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class Checkbox : BaseComponent, IClickable, IInput
    {
        public Checkbox(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public void Click()
        {
            this.GetElement();
            this.Element.Click();
        }

        public void Check()
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));

            wait.Until(_ => this.GetElement().Displayed);

            if (!this.Element.Selected)
                this.Click();
        }

        public void UnCheck()
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));

            wait.Until(_ => this.GetElement().Displayed);

            if (this.Element.Selected)
                this.Click();
        }

        public bool IsChecked()
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));

            wait.Until(_ => this.GetElement().Displayed);

            return this.Element.Selected;
        }
    }
}
