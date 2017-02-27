namespace UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.MenuItems;
    using TestStack.White.UIItems.WindowItems;

    public class MainWindow : WindowObject
    {
        private const string SIGN_OUT = "Sign out";
        private const string ACTIVE_USER_BUTTON_AUTOMATION_ID = "ActiveUserButton";

        internal MainWindow(Window window)
            : base(window)
        {
        }

        private Button ActiveUserButton => ButtonById(ACTIVE_USER_BUTTON_AUTOMATION_ID);

        private Menu SignOutMenu => Menu(SIGN_OUT);

        public void SignOutFromUserContextMenu()
        {
            ActiveUserButton.Click();
            SignOutMenu.Click();
        }
    }
}