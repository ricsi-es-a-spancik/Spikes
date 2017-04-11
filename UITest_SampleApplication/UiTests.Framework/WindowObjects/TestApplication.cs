namespace UiTests.Framework.WindowObjects
{
    using System;
    using System.Linq;

    using TestStack.White;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.Utility;

    public static class TestApplication
    {
        private const string LOGIN_WINDOW_TITLE = "LoginWindow";
        private const string MAIN_WINDOW_TITLE = "MainWindow";

        private static Application _application;

        public static LoginWindow LoginWindow => new LoginWindow(GetWindow(LOGIN_WINDOW_TITLE));

        public static MainWindow MainWindow => new MainWindow(GetWindow(MAIN_WINDOW_TITLE));

        public static NewOrganizationDialog NewOrganizationDialog => new NewOrganizationDialog(GetWindow(MAIN_WINDOW_TITLE));

        public static NewCharacterDialog NewCharacterDialog => new NewCharacterDialog(GetWindow(MAIN_WINDOW_TITLE));

        public static NewVehicleDialog NewVehicleDialog => new NewVehicleDialog(GetWindow(MAIN_WINDOW_TITLE));

        public static bool HasExited => _application.HasExited;

        public static void Init(Application application)
        {
            _application = application;
        }

        private static Window GetWindow(string title)
        {
            return Retry.For(
                () => _application.GetWindows().First(w => w.Title.Contains(title)), 
                TimeSpan.FromSeconds(5));
        }
    }
}