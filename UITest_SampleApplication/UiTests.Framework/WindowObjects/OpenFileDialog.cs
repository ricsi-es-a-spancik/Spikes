namespace UiTests.Framework.WindowObjects
{
    using System.Linq;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;

    public class OpenFileDialog : WindowObject
    {
        private const string OPEN = "Open";
        private const string EDIT = "Edit";
        private const string FILE_NAME = "File name:";

        public OpenFileDialog(Window window)
            : base(window)
        {
        }

        private IUIItem FileNameEdit => _window.GetMultiple(SearchCriteria.ByClassName(EDIT)).Single(item => item.Name.Contains(FILE_NAME));

        private Button OpenButton => Button(OPEN);

        public OpenFileDialog SetFilePath(string path)
        {
            FileNameEdit.Enter(path);
            return this;
        }

        public void Open()
        {
            OpenButton.Click();
        }
    }
}