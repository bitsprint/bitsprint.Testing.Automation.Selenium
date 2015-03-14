namespace bitsprint.Testing.Automation.Selenium.Components.WebElements
{
    using bitsprint.Testing.Automation.Selenium.Components.Interfaces;

    using OpenQA.Selenium;

    using OpenQA.Selenium.Support.UI;

    using System.Collections.Generic;

    public class DropDownBox : BaseComponent, IDropDown, IInput
    {
        public DropDownBox(By byLocator, IWebDriver driver, IWebElement parentElement = null, IWebElement element = null)
            : base(byLocator, driver, parentElement, element)
        {
        }

        public void Select(string itemToSelect)
        {
            var dropDownBox = new SelectElement(this.GetElement());
            dropDownBox.SelectByText(itemToSelect);
        }

        public IList<IWebElement> ReturnAllOptions()
        {
            var dropDownBox = new SelectElement(this.GetElement());
            return dropDownBox.Options;
        }

        public string ReturnSelectedItem()
        {
            var dropDownBox = new SelectElement(this.GetElement());
            return dropDownBox.SelectedOption.Text;
        }
    }
}
