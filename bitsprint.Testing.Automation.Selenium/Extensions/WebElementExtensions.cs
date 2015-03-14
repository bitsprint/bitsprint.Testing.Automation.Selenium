namespace bitsprint.Testing.Automation.Selenium.Extensions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public static class WebElementExtensions
    {
        public static void Hover(this IWebElement element)
        {
            var builder = new Actions(WebBrowser.Current);

            var hover = builder.MoveToElement(element);

            hover.Build().Perform();
        }

        public static IWebElement GetParentElement(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }
    }
}
