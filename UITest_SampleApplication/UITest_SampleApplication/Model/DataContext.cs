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

            Characters = new List<Character>
                             {
                                 new Character { Name = "Leia Organa", Organization = "Rebel Alliance", AvatarPath = @"Resources\Characters\leia.jpg", Details = StaticResources.LEIA_ORGANA_DETAILS },
                                 new Character { Name = "Luke Skywalker", Organization = "Rebel Alliance", AvatarPath = @"Resources\Characters\luke.jpg", Details = StaticResources.LUKE_SKYWALKER_DETAILS },
                                 new Character { Name = "Han Solo", Organization = "Rebel Alliance", AvatarPath = @"Resources\Characters\han.jpg", Details = StaticResources.HAN_SOLO_DETAILS },
                                 new Character { Name = "Chewbacca", Organization = "Rebel Alliance", AvatarPath = @"Resources\Characters\chewbacca.jpg", Details = StaticResources.CHEWBACCA_DETAILS },
                                 new Character { Name = "Darth Vader", Organization = "Galactic Empire", AvatarPath = @"Resources\Characters\vader.jpg", Details = StaticResources.DARTH_VADER_DETAILS },
                                 new Character { Name = "Darth Sidious", Organization = "Galactic Empire", AvatarPath = @"Resources\Characters\sidious.jpg", Details = StaticResources.DARTH_SIDIOUS_DETAILS },
                             };

            Vehicles = new List<Vehicle>
                           {
                               new Vehicle { Name = "Y-wing Starfighter", Organization = "Rebel Alliance", Dimensions = 23.4d },
                               new Vehicle { Name = "Millennium Falcon", Organization = "Rebel Alliance", Dimensions = 34.75d },
                               new Vehicle { Name = "X-wing Starfighter", Organization = "Rebel Alliance", Dimensions = 12.5d },
                               new Vehicle { Name = "Snowspeeder", Organization = "Rebel Alliance", Dimensions = 5.3d },
                               new Vehicle { Name = "Zeta-class Imperial Shuttle", Organization = "Rebel Alliance", Dimensions = 35.5d },
                               new Vehicle { Name = "Imperial Star Destroyer", Organization = "Galactic Empire", Dimensions = 1600.0d },
                               new Vehicle { Name = "TIE Fighter", Organization = "Galactic Empire", Dimensions = 8.99d },
                               new Vehicle { Name = "V-wing Fighter", Organization = "Galactic Empire", Dimensions = 7.9d },
                               new Vehicle { Name = "Lothal Speeder Bike", Organization = "Galactic Empire", Dimensions = 4.4d },
                               new Vehicle { Name = "AT-AT Walker", Organization = "Galactic Empire", Dimensions = 22.5d }
                           };
        }

        public List<Organization> Organizations { get; set; }

        public List<Character> Characters { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}