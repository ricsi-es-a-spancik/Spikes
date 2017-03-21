namespace UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.MenuItems;
    using TestStack.White.UIItems.TabItems;
    using TestStack.White.UIItems.WindowItems;

    public class MainWindow : WindowObject
    {
        private const string SIGN_OUT = "Sign out";
        private const string ACTIVE_USER_BUTTON_AUTOMATION_ID = "ActiveUserButton";
        private const string ORGANIZATIONS_TAB_HEADER = "Organizations";

        internal MainWindow(Window window)
            : base(window)
        {
        }

        public OrganizationsTab OrganizationsTab => new OrganizationsTab(_window);

        private Button ActiveUserButton => ButtonById(ACTIVE_USER_BUTTON_AUTOMATION_ID);

        private Menu SignOutMenu => Menu(SIGN_OUT);

        private TabPage OrganizationsTabPage => TabPage(ORGANIZATIONS_TAB_HEADER);

        public void SignOutFromUserContextMenu()
        {
            ActiveUserButton.Click();
            SignOutMenu.Click();
        }

        public void SelectOrganizationsTabPage()
        {
            OrganizationsTabPage.Select();
        }
    }
}