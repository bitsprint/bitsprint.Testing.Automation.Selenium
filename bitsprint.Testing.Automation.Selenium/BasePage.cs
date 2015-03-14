namespace bitsprint.Testing.Automation.Selenium
{
    using System.Configuration;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using bitsprint.Testing.Automation.Selenium.Attributes;
    using bitsprint.Testing.Automation.Selenium.Extensions;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    
    public class BasePage
    {
        private WebDriverWait waitForElement;

        protected string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        private readonly int TimeoutSeconds = int.Parse(ConfigurationManager.AppSettings["TimeoutSeconds"]);

        protected string PageUrl { get; set; }

        public IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver, string url)
        {
            this.Driver = driver;
            this.PageUrl = url;
            this.InitialiseFields();
        }
        
        public virtual BasePage OpenPage()
        {
            this.Driver.Navigate().GoToUrl(string.Format("{0}{1}", this.BaseUrl, this.PageUrl));

            this.Driver.Manage().Window.Maximize();

            Thread.Sleep(10000);

            if (this.waitForElement == null)
                this.waitForElement = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.TimeoutSeconds));

            this.waitForElement.Until(x => x.Url.ToString(CultureInfo.InvariantCulture).Contains(this.PageUrl));

            return this;
        }

        public void WaitForElementById(string id)
        {
            if (this.waitForElement == null)
                this.waitForElement = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.TimeoutSeconds));

            this.waitForElement.Until(x => x.FindElement(By.Id(id)));
        }

        public void WaitForElementByClassName(string className)
        {
            if (this.waitForElement == null)
                this.waitForElement = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.TimeoutSeconds));

            this.waitForElement.Until(x => x.FindElement(By.ClassName(className)));
        }

        public void WaitForElementByCssSelector(string cssSelector)
        {
            if (this.waitForElement == null)
                this.waitForElement = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.TimeoutSeconds));

            this.waitForElement.Until(x => x.FindElement(By.CssSelector(cssSelector)));
        }

        public void WaitForTextPresent(string text)
        {
            if (this.waitForElement == null)
                this.waitForElement = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.TimeoutSeconds));

            this.waitForElement.Until(x => x.PageSource.Contains(text));
        }

        public void ExecuteJavaScript(string script)
        {
            this.Driver.ExecuteJavaScript(script);
        }

        public bool IsModalOpen(string id)
        {
            if (this.waitForElement == null)
                this.waitForElement = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(this.TimeoutSeconds));

            var modal = this.waitForElement.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));

            var ariaHidden = modal.GetAttribute("aria-hidden");

            return ariaHidden == "false";
        }

        public void ScrollToTop()
        {
            this.Driver.ExecuteJavaScript("window.scrollTo(0, 0);");
        }

        private void InitialiseFields()
        {
            Array.ForEach(this.GetType().GetFields(), this.InitialiseField);
        }

        private void InitialiseField(FieldInfo field)
        {
            var attributes = field.GetCustomAttributes(typeof(ComponentLocatorAttribute), true)
                                  .Cast<ComponentLocatorAttribute>()
                                  .ToList();

            if (attributes.Count == 0) return;

            var constructor = field.FieldType.GetConstructor(new Type[] { typeof(By), typeof(IWebDriver), typeof(IWebElement), typeof(IWebElement) });

            if (constructor == null) return;

            var instance = constructor.Invoke(new object[] { attributes[0].ByLocator, this.Driver, null, null });

            field.SetValue(this, instance);
        }
    }
}
