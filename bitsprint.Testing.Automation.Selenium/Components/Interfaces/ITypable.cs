namespace bitsprint.Testing.Automation.Selenium.Components.Interfaces
{
    public interface ITypable
    {
        void EnterText(string text);

        string GetText();

        string GetValue();

        void ClearText();
    }
}
