namespace UiTests
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

        protected Button SaveButton => Button(SAVE);

        protected OpenFileDialog OpenFileDialog => new OpenFileDialog(_window);
    }
}