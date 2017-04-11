namespace UiTests.Framework.WindowObjects
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class NewCharacterDialog : NewDialog
    {
        private const string BROWSE = "...";

        public NewCharacterDialog(Window window)
            : base(window)
        {
        }

        private TextBox NameTextBox => TextBox(0);

        private ComboBox OrganizationsComboBox => ComboBox();

        private TextBox DetailsTextBox => TextBox(2);

        private Button BrowseButton => Button(BROWSE);

        public NewCharacterDialog SetName(string name)
        {
            NameTextBox.Text = name;
            return this;
        }

        public NewCharacterDialog SelectOrganization(string organization)
        {
            OrganizationsComboBox.Select(organization);
            return this;
        }

        public NewCharacterDialog SetDetails(string details)
        {
            DetailsTextBox.Text = details;
            return this;
        }

        public NewCharacterDialog SetAvatarPath(string avatarPath)
        {
            BrowseButton.Click();

            OpenFileDialog.SetFilePath(avatarPath)
                          .Open();

            return this;
        }
    }
}