namespace UiTests
{
    using System.IO;

    using NUnit.Framework;

    using UiTests.Framework.WindowObjects;
    using UiTests.Framework.Workflows;

    [TestFixture]
    public class CharactersTests : LoginTestBase
    {
        private const string NEW_ORGANIZATION_NAME = "Rebel Alliance";
        private const string NEW_CHARACTER_NAME = "Leia Organa";
        private const string NEW_CHARACTER_DETAILS = "Details of Leia Organa.";
        private string _newOrganizationDetailsPath;
        private string _newCharacterAvatarPat;

        [SetUp]
        public new void SetUp()
        {
            _newOrganizationDetailsPath = Path.Combine(ResourcesPath, "Organizations", "REBEL_ALLIANCE.rtf");
            _newCharacterAvatarPat = Path.Combine(ResourcesPath, "Characters", "leia.jpg");
        }

        [Test]
        public void CanAddNewCharacter()
        {
            OrganizationCreator.Create(NEW_ORGANIZATION_NAME, _newOrganizationDetailsPath);

            TestApplication.MainWindow.SelectCharactersTabPage();
            TestApplication.MainWindow.CharactersTab.Add();

            TestApplication.NewCharacterDialog
                           .SetName(NEW_CHARACTER_NAME)
                           .SelectOrganization(NEW_ORGANIZATION_NAME)
                           .SetAvatarPath(_newCharacterAvatarPat)
                           .SetDetails(NEW_CHARACTER_DETAILS)
                           .Save();

            Assert.True(
                        TestApplication.MainWindow.CharactersTab.IsCharacterInList(NEW_CHARACTER_NAME),
                        $"'{NEW_CHARACTER_NAME}' is expected to be in characters' list.");
        }
    }
}