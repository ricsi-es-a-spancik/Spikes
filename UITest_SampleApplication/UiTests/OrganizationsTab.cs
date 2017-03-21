namespace UiTests
{
    using System;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class OrganizationsTab : WindowObject
    {
        private const string ADD_BUTTON_AUTOMATION_ID = "AddButton";

        public OrganizationsTab(Window window)
            : base(window)
        {
        }

        private Button AddButton => ButtonById(ADD_BUTTON_AUTOMATION_ID);

        private ListBox OrganizationsListBox => ListBox();

        public void AddOrganization()
        {
            AddButton.Click();
        }

        public bool IsOrganizationInList(string organizationName)
        {
            return OrganizationsListBox.Items.Exists(item => item.Text.Equals(organizationName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}