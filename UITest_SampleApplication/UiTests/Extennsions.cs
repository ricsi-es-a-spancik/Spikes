namespace UiTests
{
    using TestStack.White.UIItems;

    public static class Extennsions
    {
        public static bool Contains(this ListView listView, VehicleInList vehicleInList)
        {
            foreach (var row in listView.Rows)
            {
                if (DataMatches(row, vehicleInList))
                    return true;
            }

            return false;
        }

        private static bool DataMatches(ListViewRow row, VehicleInList vehicleInList)
        {
            foreach (var value in vehicleInList.Values)
            {
                if (row.Cells[value.Key].Text != value.Value)
                    return false;
            }

            return true;
        }
    }
}
