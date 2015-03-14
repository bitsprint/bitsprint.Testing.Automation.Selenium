namespace bitsprint.Testing.Automation.Selenium.Components.RichWebElements
{
    using System;
    using System.Linq;
    using System.Reflection;

    using bitsprint.Testing.Automation.Selenium.Attributes;
    using bitsprint.Testing.Automation.Selenium.Enumerations;
    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;
    using bitsprint.Testing.Automation.Selenium.Components.WebElements;

    using OpenQA.Selenium;

    public class Modal : BaseComponent, IModal
    {
        [ComponentLocator(LocatorTypeEnum.Css, "div.modal-header > button")]
        public Button CloseButton;

        public Modal(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public bool IsOpen()
        {
            return this.IsElementPresentAndDisplayed();
        }

        public void Close()
        {
            this.CloseButton.Click();
        }

        public void InitialiseFields()
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

            var instance = constructor.Invoke(new object[] { attributes[0].ByLocator, this.Driver, this.GetElement(), null });

            field.SetValue(this, instance);
        }
    }
}
