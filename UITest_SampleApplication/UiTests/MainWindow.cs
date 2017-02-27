namespace UiTests
{
    using System;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.MenuItems;
    using TestStack.White.UIItems.WindowItems;

    public class MainWindow
    {
        private readonly Func<Window> _getWindow;

        public MainWindow(Func<Window> getWindow)
        {
            _getWindow = getWindow;
        }

        public bool IsCurrentlyActive => _getWindow().IsCurrentlyActive;

        private Button ActiveUserButton => _getWindow().Get<Button>(SearchCriteria.ByAutomationId("ActiveUserButton"));

        private Menu SignOutMenu => _getWindow().Get<Menu>(SearchCriteria.ByText("Sign out"));

        public void SignOutFromUserContextMenu()
        {
            ActiveUserButton.Click();
            SignOutMenu.Click();
        }
    }
}