namespace UiTests.Framework.WindowObjects
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public abstract class MainWindowTab : WindowObject
    {
        private const string ADD_BUTTON_AUTOMATION_ID = "AddButton";

        protected MainWindowTab(Window window)
            : base(window)
        {
        }

        private Button AddButton => ButtonById(ADD_BUTTON_AUTOMATION_ID);

        public void Add()
        {
            AddButton.Click();
        }
    }
}