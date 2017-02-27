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

        public static LoginWindow LoginWindow { get; private set; }

        public static MainWindow MainWindow { get; private set; }

        public static bool HasExited => _application.HasExited;

        public static void Init(Application application)
        {
            _application = application;
            LoginWindow = new LoginWindow(() => GetWindow("LoginWindow"));
            MainWindow = new MainWindow(() => GetWindow("MainWindow"));
        }

        private static Window GetWindow(string title)
        {
            return Retry.For(
                () => _application.GetWindows().First(w => w.Title.Contains(title)), 
                TimeSpan.FromSeconds(5));
        }
    }
}