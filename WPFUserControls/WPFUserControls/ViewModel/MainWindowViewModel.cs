using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFUserControls.Model;

namespace WPFUserControls.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string MainLabel { get; set; }

        public int MainValue { get; set; }

        public ObservableCollection<ResourceViewModel> Resources { get; set; }

        public ObservableCollection<Conference> League { get; set; }

        public MainWindowViewModel()
        {
            MainLabel = "MainLabel";
            MainValue = 1024;

            Resources = new ObservableCollection<ResourceViewModel>
            {
                new ResourceViewModel { StringField = "String of first", IntField = 1, BoolField = true },
                new ResourceViewModel { StringField = "String of second", IntField = 2, BoolField = false },
                new ResourceViewModel { StringField = "String of third", IntField = 3, BoolField = false }
            };

            League = new ObservableCollection<Conference>
            {
                new Conference("Western")
                {
                    Teams = new List<Team>
                    {
                        new Team("Club Deportivo Chivas USA"),
                        new Team("Colorado Rapids"),
                        new Team("FC Dallas"),
                        new Team("Houston Dynamo"),
                        new Team("Los Angeles Galaxy"),
                        new Team("Real Salt Lake"),
                        new Team("San Jose Earthquakes"),
                        new Team("Seattle Sounders FC"),
                        new Team("Portland 2011"),
                        new Team("Vancouver 2011")
                    }
                },
                new Conference("Eastern")
                {
                    Teams = new List<Team>
                    {
                        new Team("Chicago Fire"),
                        new Team("Columbus Crew"),
                        new Team("D.C. United"),
                        new Team("Kansas City Wizards"),
                        new Team("New York Red Bulls"),
                        new Team("New England Revolution"),
                        new Team("Toronto FC"),
                        new Team("Philadelphia Union 2010")
                    }
                }
            };
        }
    }
}
