namespace UiTests
{
    using NUnit.Framework;

    public class OrganizationsTests : TestBase
    {
        [SetUp]
        public new void SetUp()
        {
            PassLogin();
        }

        [Test]
        public void CanAddNewCharacter()
        {
            const string NEW_ORGANIZATION_NAME = "New Organization";
            TestApplication.MainWindow.AddOrganization();

            TestApplication.NewOrganizationDialog
                           .SetName(NEW_ORGANIZATION_NAME)
                           .SetDetailsPath(@"C:\Users\d.hornyak\Documents\REBEL_ALLIANCE.rtf")
                           .Save();

            Assert.True(
                        TestApplication.MainWindow.IsOrganizationInList(NEW_ORGANIZATION_NAME),
                        $"'{NEW_ORGANIZATION_NAME}' is expected to be in organizations' list.");
        }
    }
}