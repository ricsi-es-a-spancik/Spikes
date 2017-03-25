namespace UiTests
{
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class OrganizationsTests : TestBase
    {
        [SetUp]
        public new void SetUp()
        {
            PassLogin();
        }

        [Test]
        public void CanAddNewOrganization()
        {
            const string NEW_ORGANIZATION_NAME = "Galactic Empire";
            var newOrganizationDetailsPath = Path.Combine(ResourcesPath, "Organizations", "GALACTIC_EMPIRE.rtf");

            OrganizationCreator.Create(NEW_ORGANIZATION_NAME, newOrganizationDetailsPath);

            Assert.True(
                        TestApplication.MainWindow.OrganizationsTab.IsOrganizationInList(NEW_ORGANIZATION_NAME),
                        $"'{NEW_ORGANIZATION_NAME}' is expected to be in organizations' list.");
        }
    }
}