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

            Vehicles = new List<Vehicle>();
        }

        public List<Organization> Organizations { get; set; }

        public List<Character> Characters { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}