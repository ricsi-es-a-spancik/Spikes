namespace UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class LoginWindow : WindowObject
    {
        private const string LOGIN = "Login";
        private const string CANCEL = "Cancel";
        private const string CREDENTIALS_ERROR_MESSAGE = "The provided credentials did not match any existing user.";

        internal LoginWindow(Window window) 
            : base(window)
        {
        }

        public bool IsCredentialsErrorMessageVisible => TryGetControl(CredentialsErrorMessageLabel).Visible;

        public bool AreCredentialControlsVisible => TryGetControl(LoginNameTextBox).Visible && TryGetControl(PasswordTextBox).Visible;

        private TextBox LoginNameTextBox => TextBox(0);

        private TextBox PasswordTextBox => TextBox(1);

        private Button LoginButton => Button(LOGIN);

        private Button CancelButton => Button(CANCEL);

        private Label CredentialsErrorMessageLabel => Label(CREDENTIALS_ERROR_MESSAGE);

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
    }
}