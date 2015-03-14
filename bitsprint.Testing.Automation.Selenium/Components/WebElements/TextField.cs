namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using System;

    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class TextField : BaseComponent, ITypable, IInput
    {
        public TextField(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public void EnterText(string text)
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.Timeout));

            wait.Until(_ => this.GetElement().Displayed);
            wait.Until(_ => this.GetElement().Enabled);

            this.ClearText();

            this.GetElement().SendKeys(string.Empty);
            this.GetElement().SendKeys(text);
        }

        public string GetText()
        {
            return this.GetElement().Text;
        }

        public string GetValue()
        {
            return this.GetElement().GetAttribute("value");
        }

        public void ClearText()
        {
            this.GetElement().Clear();
        }
    }
}
