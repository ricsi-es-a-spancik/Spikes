using System.Collections.Generic;

namespace WPFUserControls.Model
{
    public class Conference
    {
        public string Name { get; set; }

        public List<Team> Teams { get; set; }

        public Conference(string name)
        {
            Name = name;
        }
    }
}
