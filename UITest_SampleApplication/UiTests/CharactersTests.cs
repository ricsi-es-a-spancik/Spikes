namespace UiTests
{
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class CharactersTests : TestBase
    {
        [SetUp]
        public new void SetUp()
        {
            PassLogin();
        }

        [Test]
        public void CanAddNewCharacter()
        {
            const string NEW_ORGANIZATION_NAME = "Rebel Alliance";
            const string NEW_CHARACTER_NAME = "Leia Organa";
            var newOrganizationDetailsPath = Path.Combine(ResourcesPath, "Organizations", "REBEL_ALLIANCE.rtf");
            var newCharacterAvatarPath = Path.Combine(ResourcesPath, "Characters", "leia.jpg");
            var newCharacterDetails = "Details of Leia Organa.";

            OrganizationCreator.Create(NEW_ORGANIZATION_NAME, newOrganizationDetailsPath);

            CharacterCreator.Create(NEW_CHARACTER_NAME, NEW_ORGANIZATION_NAME, newCharacterAvatarPath, newCharacterDetails);

            Assert.True(
                        TestApplication.MainWindow.CharactersTab.IsCharacterInList(NEW_CHARACTER_NAME),
                        $"'{NEW_CHARACTER_NAME}' is expected to be in characters' list.");
        }
    }
}