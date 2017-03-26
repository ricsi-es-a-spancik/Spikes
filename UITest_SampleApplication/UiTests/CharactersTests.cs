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

            CharacterCreator.Create(NEW_CHARACTER_NAME, NEW_ORGANIZATION_NAME, _newCharacterAvatarPat, NEW_CHARACTER_DETAILS);

            Assert.True(
                        TestApplication.MainWindow.CharactersTab.IsCharacterInList(NEW_CHARACTER_NAME, NEW_ORGANIZATION_NAME),
                        $"'{NEW_CHARACTER_NAME}' is expected to be in characters' list.");
        }

        [Test]
        public void CanOpenCharacterDetailsFlyout()
        {
            OrganizationCreator.Create(NEW_ORGANIZATION_NAME, _newOrganizationDetailsPath);
            CharacterCreator.Create(NEW_CHARACTER_NAME, NEW_ORGANIZATION_NAME, _newCharacterAvatarPat, NEW_CHARACTER_DETAILS);

            TestApplication.MainWindow.CharactersTab.OpenCharacterDetails(NEW_CHARACTER_NAME, NEW_ORGANIZATION_NAME);

            Assert.True(
                TestApplication.MainWindow.CharacterDetailsFlyout.IsVIsible,
                "Character details flyout control is excpected to be visible.");

            Assert.True(
                TestApplication.MainWindow.CharacterDetailsFlyout.ContainsValues(NEW_CHARACTER_NAME, NEW_ORGANIZATION_NAME, NEW_CHARACTER_DETAILS),
                $"Characted details flyout control is excepted to contain the following values: Name - {NEW_CHARACTER_NAME}; Organization - {NEW_ORGANIZATION_NAME}; Details - {NEW_CHARACTER_DETAILS}");
        }
    }
}