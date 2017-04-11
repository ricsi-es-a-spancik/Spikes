namespace UiTests.Framework.WindowObjects
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WPFUIItems;

    public class CharacterPreviewItem
    {
        private readonly IUIItem _uiItem;

        public CharacterPreviewItem(IUIItem uiItem)
        {
            _uiItem = uiItem;
        }

        public Label Name => _uiItem.Get<Label>(SearchCriteria.Indexed(0));

        public Label Organization => _uiItem.Get<Label>(SearchCriteria.Indexed(1));

        public Button DetailsButton => _uiItem.Get<Button>(SearchCriteria.ByText("Details"));
    }
}