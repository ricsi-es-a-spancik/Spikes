namespace UiTests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using TestStack.White;

    [TestFixture]
    public class SmokeTests
    {
        private const string EXECUTABLE = @"C:\Users\d.hornyak\gitrepo\Spikes\UITest_SampleApplication\UITest_SampleApplication\bin\Debug\UITest_SampleApplication.exe";
        private const string USER_LOGIN_NAME = "Mr. Asd";

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            var application = Application.Launch(EXECUTABLE);
            TestApplication.Init(application);
        }

        [TearDown]
        public void TearDown()
        {
            if (!TestApplication.HasExited && TestApplication.LoginWindow.IsCurrentlyActive)
                TestApplication.LoginWindow.Close();
        }

        [Test]
        public void CanRedirectToCredentialsViewAfterLoginFailed()
        {
            FailLogin();

            TestApplication.LoginWindow.ClickLoginButton();

            Assert.True(TestApplication.LoginWindow.AreCredentialControlsVisible);
        }

        [Test]
        public void ApplicationCanBeClosedAfterLoginFailed()
        {
            FailLogin();

            TestApplication.LoginWindow.ClickCancelButton();

            Assert.True(TestApplication.HasExited);
        }

        [Test]
        public void CanSignOutFromActiveUsersContextMenu()
        {
            PassLogin();

            TestApplication.MainWindow.SignOutFromUserContextMenu();

            Assert.True(TestApplication.LoginWindow.AreCredentialControlsVisible);
        }

        private static void PassLogin()
        {
            TestApplication.LoginWindow.Login(USER_LOGIN_NAME, string.Empty);

            Assert.True(TestApplication.MainWindow.IsCurrentlyActive);
        }

        private static void FailLogin()
        {
            TestApplication.LoginWindow.Login(string.Empty, string.Empty);

            Assert.True(TestApplication.LoginWindow.IsCredentialsErrorMessageVisible);
        }
    }
}
