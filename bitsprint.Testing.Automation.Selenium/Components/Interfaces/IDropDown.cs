namespace bitsprint.Testing.Automation.Selenium.Components.Interfaces
{
    public interface IDropDown : IList
    {
        void Select(string itemToSelect);

        string ReturnSelectedItem();
    }
}
