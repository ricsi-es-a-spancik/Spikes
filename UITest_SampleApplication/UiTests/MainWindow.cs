namespace UiTests
{
    using System;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.MenuItems;
    using TestStack.White.UIItems.TabItems;
    using TestStack.White.UIItems.WindowItems;

    public class MainWindow : WindowObject
    {
        private const string SIGN_OUT = "Sign out";
        private const string ACTIVE_USER_BUTTON_AUTOMATION_ID = "ActiveUserButton";
        private const string ORGANIZATIONS_TAB_HEADER = "Organizations";
        private const string CHARACTERS_TAB_HEADER = "Characters";
        private const string ADD_BUTTON_AUTOMATION_ID = "AddButton";

        internal MainWindow(Window window)
            : base(window)
        {
        }

        private Button ActiveUserButton => ButtonById(ACTIVE_USER_BUTTON_AUTOMATION_ID);

        private Menu SignOutMenu => Menu(SIGN_OUT);

        private TabPage OrganizationsTab => TabPage(ORGANIZATIONS_TAB_HEADER);

        private TabPage CharactersTab => TabPage(CHARACTERS_TAB_HEADER);

        private Button AddButton => ButtonById(ADD_BUTTON_AUTOMATION_ID);

        private ListBox OrganizationsListBox => ListBox();

        public void AddOrganization()
        {
            OrganizationsTab.Select();
            AddButton.Click();
        }

        public void AddCharacter()
        {
            CharactersTab.Select();
            AddButton.Click();
        }

        public void SignOutFromUserContextMenu()
        {
            ActiveUserButton.Click();
            SignOutMenu.Click();
        }

        public bool IsOrganizationInList(string organizationName)
        {
            return OrganizationsListBox.Items.Exists(item => item.Text.Equals(organizationName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}