namespace UiTests
{
    using System.Collections.Generic;

    public class VehicleInList
    {
        private readonly Dictionary<string, string> _values = new Dictionary<string, string>();

        public VehicleInList(string name, string organization, double dimension)
        {
            _values["Name"] = name;
            _values["Organization"] = organization;
            _values["Dimensions"] = dimension.ToString("G");
        }

        public IReadOnlyDictionary<string, string> Values => _values;
    }
}