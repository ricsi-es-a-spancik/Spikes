namespace UiTests
{
    using NUnit.Framework;

    public abstract class LoginTestBase : TestBase
    {
        [SetUp]
        public new void SetUp()
        {
            PassLogin();
        }
    }
}