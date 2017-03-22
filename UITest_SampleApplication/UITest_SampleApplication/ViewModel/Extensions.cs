namespace UITest_SampleApplication.ViewModel
{
    using System.Linq;

    using UITest_SampleApplication.Model;

    public static class Extensions
    {
        public static OrganizationViewModel ToViewModel(this Organization organization)
        {
            return new OrganizationViewModel
                       {
                           Name = organization.Name,
                           DetailsPath = organization.DetailsPath
                       };
        }

        public static CharacterViewModel ToViewModel(this Character character)
        {
            return new CharacterViewModel
                       {
                           Name = character.Name,
                           Organization = character.Organization.ToViewModel(),
                           Details = character.Details,
                           AvatarPath = character.AvatarPath
                       };
        }

        public static VehicleViewModel ToViewModel(this Vehicle vehicle)
        {
            return new VehicleViewModel
                       {
                           Name = vehicle.Name,
                           Organization = vehicle.Organization.ToViewModel(),
                           Dimensions = vehicle.Dimensions
                       };
        }

        public static Organization ToModel(this OrganizationViewModel organizationViewModel)
        {
            return new Organization
                       {
                           Name = organizationViewModel.Name,
                           DetailsPath = organizationViewModel.DetailsPath
                       };
        }

        public static Character ToModel(this CharacterViewModel characterViewModel, IDataContext dataContext)
        {
            return new Character
            {
                Name = characterViewModel.Name,
                Organization = characterViewModel.Organization.MapToModel(dataContext),
                Details = characterViewModel.Details,
                AvatarPath = characterViewModel.AvatarPath
            };
        }

        public static Vehicle ToModel(this VehicleViewModel vehicleViewModel, IDataContext dataContext)
        {
            return new Vehicle
            {
                Name = vehicleViewModel.Name,
                Organization = vehicleViewModel.Organization.MapToModel(dataContext),
                Dimensions = vehicleViewModel.Dimensions
            };
        }

        private static Organization MapToModel(this OrganizationViewModel organizationViewModel, IDataContext dataContext)
        {
            return dataContext.Organizations.Single(org => org.Name == organizationViewModel.Name);
        }
    }
}
