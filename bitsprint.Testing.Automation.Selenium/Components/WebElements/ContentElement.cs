namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;

    public class ContentElement : BaseComponent, IReadable
    {
        public ContentElement(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public string GetValue()
        {
            this.Element = this.GetElement();
            return this.Element.GetAttribute("value");
        }

        public string GetText()
        {
            this.Element = this.GetElement();
            return Element.Text;
        }
    }
}
