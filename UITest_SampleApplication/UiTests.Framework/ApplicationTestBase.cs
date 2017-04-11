﻿namespace UiTests.Framework
{
    using System.Configuration;

    using NUnit.Framework;

    using TestStack.White;

    using UiTests.Framework.WindowObjects;

    public abstract class ApplicationTestBase
    {
        private const string SAMPLE_APPLICATION_PATH = "UITest_SampleApplicationExecutablePath";
        private const string USER_LOGIN_NAME = "Mr. Asd";

        private Application _application;

        [SetUp]
        public void SetUp()
        {
            _application = Application.Launch(ConfigurationManager.AppSettings[SAMPLE_APPLICATION_PATH]);
            TestApplication.Init(_application);
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