namespace UiTests
{
    using System;
    using System.Linq;

    using TestStack.White;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.Utility;

    public static class TestApplication
    {
        private static Application _application;

        public static LoginWindow LoginWindow => new LoginWindow(GetWindow("LoginWindow"));

        public static MainWindow MainWindow => new MainWindow(GetWindow("MainWindow"));

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