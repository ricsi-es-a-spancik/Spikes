namespace UiTests.Framework.WindowObjects
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public abstract class NewDialog : WindowObject
    {
        private const string SAVE = "Save";

        protected NewDialog(Window window)
            : base(window)
        {
        }

        protected OpenFileDialog OpenFileDialog => new OpenFileDialog(_window);

        private Button SaveButton => Button(SAVE);

        public void Save()
        {
            SaveButton.Click();
        }
    }
}