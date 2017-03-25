namespace UiTests
{
    using System;
    using System.Threading.Tasks;

    using TestStack.White.UIItems;
    using TestStack.White.UIItems.WindowItems;

    public class VehiclesTab : MainWindowTab
    {
        public VehiclesTab(Window window)
            : base(window)
        {
        }

        private ListView DataGrid => ListView();

        public bool IsVehicleInList(string name, string organization, double dimensions)
        {
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            return DataGrid.Contains(new VehicleInList(name, organization, dimensions));
        }
    }
}