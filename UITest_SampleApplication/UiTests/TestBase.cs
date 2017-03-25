namespace UiTests
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Reflection;

    using NUnit.Framework;

    using TestStack.White;

    public abstract class TestBase
    {
        private const string SAMPLE_APPLICATION_PATH = "UITest_SampleApplicationExecutablePath";
        private const string USER_LOGIN_NAME = "Mr. Asd";
        private const string RESOURCES = "Resources";

        private Application _application;

        protected string ResourcesPath { get; private set; }

        [SetUp]
        public void SetUp()
        {
            _application = Application.Launch(ConfigurationManager.AppSettings[SAMPLE_APPLICATION_PATH]);
            TestApplication.Init(_application);

            var uiTestAssemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (string.IsNullOrEmpty(uiTestAssemblyDir))
                throw new InvalidOperationException("Directory of UI Test assembly cannot be located.");

            ResourcesPath = Path.Combine(uiTestAssemblyDir, RESOURCES);
        }

        [TearDown]
        public void TearDown()
        {
            _application.Kill();
        }

        protected static void PassLogin()
        {
            TestApplication.LoginWindow.Login(USER_LOGIN_NAME, string.Empty);

            Assert.True(TestApplication.MainWindow.IsCurrentlyActive);
        }

        protected static void FailLogin()
        {
            TestApplication.LoginWindow.Login(string.Empty, string.Empty);

            Assert.True(TestApplication.LoginWindow.IsCredentialsErrorMessageVisible);
        }
    }
}