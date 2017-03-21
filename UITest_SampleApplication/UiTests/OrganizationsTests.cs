namespace UiTests
{
    using System.IO;

    using NUnit.Framework;

    public class OrganizationsTests : TestBase
    {
        [SetUp]
        public new void SetUp()
        {
            PassLogin();
            TestApplication.MainWindow.SelectOrganizationsTabPage();
        }

        [Test]
        public void CanAddNewCharacter()
        {
            const string NEW_ORGANIZATION_NAME = "Galactic Empire";
            var newOrganizationDetailsPath = Path.Combine(ResourcesPath, "Organizations", "GALACTIC_EMPIRE.rtf");

            TestApplication.MainWindow.OrganizationsTab.AddOrganization();

            TestApplication.NewOrganizationDialog
                           .SetName(NEW_ORGANIZATION_NAME)
                           .SetDetailsPath(newOrganizationDetailsPath)
                           .Save();

            Assert.True(
                        TestApplication.MainWindow.OrganizationsTab.IsOrganizationInList(NEW_ORGANIZATION_NAME),
                        $"'{NEW_ORGANIZATION_NAME}' is expected to be in organizations' list.");
        }
    }
}