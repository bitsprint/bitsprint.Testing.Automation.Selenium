namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using System.Collections.Generic;

    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;

    public class Table : BaseComponent, ITable
    {
        public Table(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public IList<IWebElement> ReturnAllRows()
        {
            return this.GetElement().FindElements(By.CssSelector("tr"));
        }

        public IWebElement ReturnTableHeader()
        {
            return this.GetElement().FindElement(By.CssSelector("thead"));
        }

        public IWebElement ReturnTableBody()
        {
            return this.GetElement().FindElement(By.CssSelector("tbody"));
        }
    }
}
