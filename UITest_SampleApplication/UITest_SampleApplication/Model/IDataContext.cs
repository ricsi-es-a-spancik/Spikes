namespace UITest_SampleApplication.Model
{
    using System.Collections.Generic;

    public interface IDataContext
    {
        List<Organization> Organizations { get; set; }

        List<Character> Characters { get; set; }

        List<Vehicle> Vehicles { get; set; }
    }
}