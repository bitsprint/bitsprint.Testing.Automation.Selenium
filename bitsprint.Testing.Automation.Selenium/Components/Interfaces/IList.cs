﻿namespace bitsprint.Testing.Automation.Selenium.Components.Interfaces
{
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public interface IList
    {
        IList<IWebElement> ReturnAllOptions();
    }
}
