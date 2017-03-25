namespace UiTests
{
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;

    public class NewVehicleDialog : NewDialog
    {
        public NewVehicleDialog(Window window)
            : base(window)
        {
        }

        private TextBox NameTextBox => TextBox(0);

        private ComboBox OrganizationsComboBox => ComboBox();

        private TextBox DimensionTextBox => TextBox(1);

        public NewVehicleDialog SetName(string name)
        {
            NameTextBox.Text = name;
            return this;
        }

        public NewVehicleDialog SelectOrganization(string organization)
        {
            OrganizationsComboBox.Select(organization);
            return this;
        }

        public NewVehicleDialog SetDimensions(double dimensions)
        {
            DimensionTextBox.Text = dimensions.ToString("G");
            return this;
        }
    }
}