namespace UiTests
{
    using System;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.MenuItems;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.Utility;

    public class WindowObject
    {
        protected readonly Window _window;

        protected WindowObject(Window window)
        {
            _window = window;
        }

        public bool IsCurrentlyActive => _window.IsCurrentlyActive;

        protected Button Button(string content)
        {
            return _window.Get<Button>(SearchCriteria.ByText(content));
        }

        protected Button ButtonById(string automationId)
        {
            return _window.Get<Button>(SearchCriteria.ByAutomationId(automationId));
        }

        protected Label Label(string content)
        {
            return _window.Get<Label>(SearchCriteria.ByText(content));
        }

        protected TextBox TextBox(int index)
        {
            return _window.Get<TextBox>(SearchCriteria.Indexed(index));
        }

        protected Menu Menu(string text)
        {
            return _window.Get<Menu>(SearchCriteria.ByText(text));
        }

        protected T TryGetControl<T>(T control, double defaultTimeoutInSeconds = 5)
        {
            return Retry.For(() => control, TimeSpan.FromSeconds(defaultTimeoutInSeconds));
        }
    }
}