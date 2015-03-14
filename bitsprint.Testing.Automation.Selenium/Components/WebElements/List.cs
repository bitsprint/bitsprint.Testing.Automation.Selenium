namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class List : BaseComponent, IList
    {
        public List(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public IList<IWebElement> ReturnAllOptions()
        {
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));

            return wait.Until(_ => this.GetElement().FindElements(By.TagName("li")));
        }

        public void SelectOption(string text)
        {
            var option = this.ReturnAllOptions().FirstOrDefault(_ => _.Text == text);

            if (option != null)
            {
                option.Click();
            }
        }
    }
}
