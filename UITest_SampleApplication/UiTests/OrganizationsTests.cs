namespace UiTests
{
    using System.IO;

    using NUnit.Framework;

    using UiTests.Framework.WindowObjects;
    using UiTests.Framework.Workflows;

    [TestFixture]
    public class OrganizationsTests : LoginTestBase
    {
        private const string NEW_ORGANIZATION_NAME = "Galactic Empire";
        private string _newOrganizationDetailsPath;

        [SetUp]
        public new void SetUp()
        {
            _newOrganizationDetailsPath = Path.Combine(ResourcesPath, "Organizations", "GALACTIC_EMPIRE.rtf");
        }

        [Test]
        public void CanAddNewOrganization()
        {
            OrganizationCreator.Create(NEW_ORGANIZATION_NAME, _newOrganizationDetailsPath);

            Assert.True(
                        TestApplication.MainWindow.OrganizationsTab.IsOrganizationInList(NEW_ORGANIZATION_NAME),
                        $"'{NEW_ORGANIZATION_NAME}' is expected to be in organizations' list.");
        }
    }
}