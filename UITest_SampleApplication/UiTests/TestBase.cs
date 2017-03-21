namespace UiTests
{
    using System.Configuration;

    using NUnit.Framework;

    using TestStack.White;

    public abstract class TestBase
    {
        private const string USER_LOGIN_NAME = "Mr. Asd";
        private Application _application;

        [SetUp]
        public void SetUp()
        {
            _application = Application.Launch(ConfigurationManager.AppSettings["UITest_SampleApplicationExecutablePath"]);
            TestApplication.Init(_application);
        }

        [TearDown]
        public void TearDown()
        {
            _application.Close();
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