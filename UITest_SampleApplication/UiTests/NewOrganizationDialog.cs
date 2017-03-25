namespace UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class NewOrganizationDialog : NewDialog
    {
        private const string BROWSE = "...";

        public NewOrganizationDialog(Window window)
            : base(window)
        {
        }

        private TextBox NameTextBox => TextBox(0);

        private Button BrowseButton => Button(BROWSE);

        public NewOrganizationDialog SetName(string name)
        {
            NameTextBox.Text = name;
            return this;
        }

        public NewOrganizationDialog SetDetailsPath(string path)
        {
            BrowseButton.Click();

            OpenFileDialog.SetFilePath(path)
                          .Open();

            return this;
        }
    }
}