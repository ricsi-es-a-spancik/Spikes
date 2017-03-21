namespace UiTests
{
    using NUnit.Framework;

    [TestFixture]
    public class AuthenticationTests : TestBase
    {

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
    }
}
