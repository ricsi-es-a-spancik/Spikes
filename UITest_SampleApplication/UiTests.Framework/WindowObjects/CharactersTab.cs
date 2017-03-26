namespace UiTests.Framework.WindowObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;

    public class CharactersTab : MainWindowTab
    {
        private const string CHARACTER_PREVIEW_ITEM_ID = "CharacterPreviewItem";

        public CharactersTab(Window window)
            : base(window)
        {
        }

        private List<CharacterPreviewItem> CharacterPreviews => _window.GetMultiple(SearchCriteria.ByAutomationId(CHARACTER_PREVIEW_ITEM_ID))
                                                                       .Select(item => new CharacterPreviewItem(item))
                                                                       .ToList();

        public bool IsCharacterInList(string name, string organization)
        {
            return GetPreviewItem(name, organization) != null;
        }

        public void OpenCharacterDetails(string name, string organization)
        {
            Task.Delay(TimeSpan.FromMilliseconds(500)).Wait();
            GetPreviewItem(name, organization).DetailsButton.Click();
        }

        private CharacterPreviewItem GetPreviewItem(string name, string organization)
        {
            return CharacterPreviews.FirstOrDefault(preview => preview.Name.Text == name && preview.Organization.Text == organization);
        }
    }
}