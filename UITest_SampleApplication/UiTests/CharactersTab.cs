namespace UiTests
{
    using System.Linq;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.UIItems.WPFUIItems;

    public class CharactersTab : MainWindowTab
    {
        public CharactersTab(Window window)
            : base(window)
        {
        }

        public bool IsCharacterInList(string name)
        {
            var character = _window.GetMultiple(SearchCriteria.ByAutomationId("CharacterPreviewItem")).Single();
            return character.Get<Label>(SearchCriteria.ByText(name)) != null;
        }
    }
}