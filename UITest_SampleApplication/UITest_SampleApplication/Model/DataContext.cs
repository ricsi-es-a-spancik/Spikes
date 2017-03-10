namespace UITest_SampleApplication.Model
{
    using System.Collections.Generic;

    public class DataContext : IDataContext
    {
        public DataContext()
        {
            Organizations = new List<Organization>
                                {
                                    new Organization { Name = "Galactic Empire", DetailsPath = @"Resources\Organizations\GALACTIC_EMPIRE.rtf" },
                                    new Organization { Name = "Rebel Alliance", DetailsPath = @"Resources\Organizations\REBEL_ALLIANCE.rtf" }
                                };

            Characters = new List<Character>();
            Vehicles = new List<Vehicle>();
        }

        public List<Organization> Organizations { get; set; }

        public List<Character> Characters { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}