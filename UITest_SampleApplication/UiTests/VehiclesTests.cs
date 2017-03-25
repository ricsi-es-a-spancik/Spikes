namespace UiTests
{
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class VehiclesTests : LoginTestBase
    {
        private const string NEW_ORGANIZATION_NAME = "Rebel Alliance";
        private const string NEW_VEHICLE_NAME = "Millennium Falcon";
        private const double NEW_VEHICLE_DIMENSIONS = 42.11d;
        private string _newOrganizationDetailsPath;

        [SetUp]
        public new void SetUp()
        {
            _newOrganizationDetailsPath = Path.Combine(ResourcesPath, "Organizations", "REBEL_ALLIANCE.rtf");
        }

        [Test]
        public void CanAddNewVehicle()
        {
            OrganizationCreator.Create(NEW_ORGANIZATION_NAME, _newOrganizationDetailsPath);

            TestApplication.MainWindow.SelectVehiclesTabPage();
            TestApplication.MainWindow.VehiclesTab.Add();

            TestApplication.NewVehicleDialog
                           .SetName(NEW_VEHICLE_NAME)
                           .SelectOrganization(NEW_ORGANIZATION_NAME)
                           .SetDimensions(NEW_VEHICLE_DIMENSIONS)
                           .Save();

            Assert.True(
                        TestApplication.MainWindow.VehiclesTab.IsVehicleInList(NEW_VEHICLE_NAME, NEW_ORGANIZATION_NAME, NEW_VEHICLE_DIMENSIONS),
                        $"'{NEW_VEHICLE_NAME}' is expected to be in vehicles' list.");
        }
    }
}