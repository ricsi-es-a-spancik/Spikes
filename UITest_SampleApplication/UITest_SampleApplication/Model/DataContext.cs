namespace UITest_SampleApplication.Model
{
    using System.Collections.Generic;

    public class DataContext : IDataContext
    {
        public DataContext()
        {
            Organizations = new List<Organization>();
            Characters = new List<Character>();
            Vehicles = new List<Vehicle>();
        }

        public List<Organization> Organizations { get; set; }

        public List<Character> Characters { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}