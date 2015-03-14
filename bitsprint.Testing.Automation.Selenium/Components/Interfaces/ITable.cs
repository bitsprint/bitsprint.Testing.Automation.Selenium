namespace bitsprint.Testing.Automation.Selenium.Components.Interfaces
{
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public interface ITable
    {
        IList<IWebElement> ReturnAllRows();

        IWebElement ReturnTableHeader();

        IWebElement ReturnTableBody();
    }
}
