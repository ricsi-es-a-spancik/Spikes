namespace UiTests.Framework.WindowObjects
{
    using System;
    using System.Threading.Tasks;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.MenuItems;
    using TestStack.White.UIItems.TabItems;
    using TestStack.White.UIItems.WindowItems;

    public class MainWindow : WindowObject
    {
        private const string SIGN_OUT = "Sign out";
        private const string ACTIVE_USER_BUTTON_AUTOMATION_ID = "ActiveUserButton";
        private const string ORGANIZATIONS_TAB_HEADER = "Organizations";
        private const string CHARACTERS_TAB_HEADER = "Characters";
        private const string VEHICLES_TAB_HEADER = "Vehicles";

        internal MainWindow(Window window)
            : base(window)
        {
        }

        public OrganizationsTab OrganizationsTab => new OrganizationsTab(_window);

        public CharactersTab CharactersTab => new CharactersTab(_window);

        public VehiclesTab VehiclesTab => new VehiclesTab(_window);

        private Button ActiveUserButton => ButtonById(ACTIVE_USER_BUTTON_AUTOMATION_ID);

        private Menu SignOutMenu => Menu(SIGN_OUT);

        private TabPage OrganizationsTabPage => TabPage(ORGANIZATIONS_TAB_HEADER);

        private TabPage CharactersTabPage => TabPage(CHARACTERS_TAB_HEADER);

        private TabPage VehiclesTabPage => TabPage(VEHICLES_TAB_HEADER);

        public void SignOutFromUserContextMenu()
        {
            ActiveUserButton.Click();
            SignOutMenu.Click();
        }

        public void SelectOrganizationsTabPage()
        {
            OrganizationsTabPage.Select();
            Task.Delay(TimeSpan.FromMilliseconds(500)).Wait();
        }

        public void SelectCharactersTabPage()
        {
            CharactersTabPage.Select();
            Task.Delay(TimeSpan.FromMilliseconds(500)).Wait();
        }

        public void SelectVehiclesTabPage()
        {
            VehiclesTabPage.Select();
            Task.Delay(TimeSpan.FromMilliseconds(500)).Wait();
        }
    }
}