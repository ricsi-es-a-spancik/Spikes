namespace UiTests
{
    internal static class CharacterCreator
    {
        public static void Create(string name, string organization, string avatarPath, string details)
        {
            TestApplication.MainWindow.SelectCharactersTabPage();
            TestApplication.MainWindow.CharactersTab.Add();

            TestApplication.NewCharacterDialog
                           .SetName(name)
                           .SelectOrganization(organization)
                           .SetAvatarPath(avatarPath)
                           .SetDetails(details)
                           .Save();
        }
    }
}