namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using System.Threading;

    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public class Button : BaseComponent, IClickable
    {
        public Button(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public void Click()
        {
            var period = 0;

            while (!this.GetElement().Enabled || !this.GetElement().Displayed || period > 10000)
            {
                Thread.Sleep(1000);
                period += 1000;
            }

            this.GetElement().SendKeys(string.Empty);

            new Actions(this.Driver).MoveToElement(this.GetElement()).Click().Perform();
        }
    }
}
