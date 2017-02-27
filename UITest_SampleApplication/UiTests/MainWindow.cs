namespace UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.MenuItems;
    using TestStack.White.UIItems.WindowItems;

    public class MainWindow
    {
        private readonly Window _window;

        public MainWindow(Window window)
        {
            _window = window;
        }

        public bool IsCurrentlyActive => _window.IsCurrentlyActive;

        private Button ActiveUserButton => _window.Get<Button>(SearchCriteria.ByAutomationId("ActiveUserButton"));

        private Menu SignOutMenu => _window.Get<Menu>(SearchCriteria.ByText("Sign out"));

        public void SignOutFromUserContextMenu()
        {
            ActiveUserButton.Click();
            SignOutMenu.Click();
        }
    }
}