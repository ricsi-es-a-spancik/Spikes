namespace UiTests
{
    using System;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.Utility;

    public class LoginWindow
    {
        private const string CREDENTIALS_ERROR_MESSAGE = "The provided credentials did not match any existing user.";

        private readonly Window _window;

        public LoginWindow(Window window)
        {
            _window = window;
        }

        public bool IsCredentialsErrorMessageVisible => Retry.For(() => CredentialsErrorMessageLabel, TimeSpan.FromSeconds(5)).Visible;

        public bool AreCredentialControlsVisible => Retry.For(() => LoginNameTextBox, TimeSpan.FromSeconds(5)).Visible && PasswordTextBox.Visible;

        public bool IsCurrentlyActive => _window.IsCurrentlyActive;

        private TextBox LoginNameTextBox => _window.Get<TextBox>(SearchCriteria.Indexed(0));

        private TextBox PasswordTextBox => _window.Get<TextBox>(SearchCriteria.Indexed(1));

        private Button LoginButton => _window.Get<Button>(SearchCriteria.ByText("Login"));

        private Button CancelButton => _window.Get<Button>(SearchCriteria.ByText("Cancel"));

        private Label CredentialsErrorMessageLabel => _window.Get<Label>(SearchCriteria.ByText(CREDENTIALS_ERROR_MESSAGE));

        public void Login(string loginName, string password)
        {
            LoginNameTextBox.Text = loginName;
            PasswordTextBox.Text = password;

            ClickLoginButton();
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        public void Close()
        {
            _window.Close();
        }
    }
}