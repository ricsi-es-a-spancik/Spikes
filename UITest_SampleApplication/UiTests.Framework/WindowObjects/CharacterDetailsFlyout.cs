namespace UiTests.Framework.WindowObjects
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.UIItems.WPFUIItems;

    public class CharacterDetailsFlyout : WindowObject
    {
        private const string CHARACTER_DETAILS_FLYOUT_ID = "CharacterDetailsFlyout";

        public CharacterDetailsFlyout(Window window)
            : base(window)
        {
        }

        public bool IsVIsible => Content.Visible;

        private IUIItem Content => _window.Get(SearchCriteria.ByAutomationId(CHARACTER_DETAILS_FLYOUT_ID));

        private Label Name => Content.Get<Label>(SearchCriteria.Indexed(0));

        private Label Organization => Content.Get<Label>(SearchCriteria.Indexed(1));

        private Label Details => Content.Get<Label>(SearchCriteria.Indexed(2));

        public bool ContainsValues(string name, string organization, string details)
        {
            return Name.Text == name && Organization.Text == organization && Details.Text == details;
        }
    }
}