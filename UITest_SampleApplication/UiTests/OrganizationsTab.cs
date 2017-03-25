namespace UiTests
{
    using System;

    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class OrganizationsTab : MainWindowTab
    {
        public OrganizationsTab(Window window)
            : base(window)
        {
        }

        private ListBox OrganizationsListBox => ListBox();

        public bool IsOrganizationInList(string organizationName)
        {
            return OrganizationsListBox.Items.Exists(item => item.Text.Equals(organizationName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}