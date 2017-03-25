namespace UiTests
{
    using System.Linq;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.UIItems.WPFUIItems;

    public class CharactersTab : MainWindowTab
    {
        private const string CHARACTER_PREVIEW_ITEM_ID = "CharacterPreviewItem";

        public CharactersTab(Window window)
            : base(window)
        {
        }

        public bool IsCharacterInList(string name)
        {
            var character = _window.GetMultiple(SearchCriteria.ByAutomationId(CHARACTER_PREVIEW_ITEM_ID)).Single();
            return character.Get<Label>(SearchCriteria.ByText(name)) != null;
        }
    }
}