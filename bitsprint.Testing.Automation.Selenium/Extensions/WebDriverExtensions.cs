namespace bitsprint.Testing.Automation.Selenium.Extensions
{
    using OpenQA.Selenium;

    public static class WebDriverExtensions
    {
        public static void ExecuteJavaScript(this IWebDriver driver, string script)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        public static IWebDriver GetFrame(this IWebDriver driver, string name)
        {
            return driver.SwitchTo().Frame(name);
        }
    }
}
