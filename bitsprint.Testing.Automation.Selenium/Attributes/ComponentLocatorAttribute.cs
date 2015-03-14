namespace bitsprint.Testing.Automation.Selenium.Attributes
{
    using System;

    using bitsprint.Testing.Automation.Selenium.Enumerations;

    using OpenQA.Selenium;

    [AttributeUsage(AttributeTargets.Field)]
    public class ComponentLocatorAttribute : Attribute
    {
        public string DefaultInput { get; private set; }

        public string BindedDataAttribute { get; private set; }

        public bool IsMandatory { get; private set; }

        public bool IsRepeatingGroup { get; private set; }

        public By ByLocator { get; private set; }

        public string Locator { get; private set; }

        public ComponentLocatorAttribute(LocatorTypeEnum locatorType, string locator)
            : this(locatorType, locator, string.Empty)
        {
            this.Locator = locator;
        }

        public ComponentLocatorAttribute(LocatorTypeEnum locatorType, string locator, string defaultInput)
        {
            this.DefaultInput = defaultInput;
            this.ParseByDetails(locatorType, locator);
        }

        public ComponentLocatorAttribute(LocatorTypeEnum locatorType, string locator, string defaultInput,
            string bindedDataAttribute, bool isMandatory)
        {
            this.Locator = locator;
            this.DefaultInput = defaultInput;
            this.BindedDataAttribute = bindedDataAttribute;
            this.IsMandatory = isMandatory;
            this.ParseByDetails(locatorType, locator);
        }

        public ComponentLocatorAttribute(LocatorTypeEnum locatorType, string locator, string defaultInput,
            string bindedDataAttribute, bool isMandatory, bool isRepeatingGroup)
        {
            this.Locator = locator;
            this.DefaultInput = defaultInput;
            this.BindedDataAttribute = bindedDataAttribute;
            this.IsMandatory = isMandatory;
            this.IsRepeatingGroup = isRepeatingGroup;
            this.ParseByDetails(locatorType, locator);
        }

        private void ParseByDetails(LocatorTypeEnum locatorTypeEnum, string locator)
        {
            switch (locatorTypeEnum)
            {
                case LocatorTypeEnum.Id:
                    this.ByLocator = By.Id(locator);
                    break;
                case LocatorTypeEnum.XPath:
                    this.ByLocator = By.XPath(locator);
                    break;
                case LocatorTypeEnum.PartialLinkText:
                    this.ByLocator = By.PartialLinkText(locator);
                    break;
                case LocatorTypeEnum.ClassName:
                    this.ByLocator = By.ClassName(locator);
                    break;
                case LocatorTypeEnum.Name:
                    this.ByLocator = By.Name(locator);
                    break;
                case LocatorTypeEnum.Css:
                    this.ByLocator = By.CssSelector(locator);
                    break;
                default:
                    this.ByLocator = By.TagName(locator);
                    break;
            }
        }

    }
}
