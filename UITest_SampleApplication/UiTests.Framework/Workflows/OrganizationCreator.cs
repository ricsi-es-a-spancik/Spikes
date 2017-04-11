namespace UiTests.Framework.Workflows
{
    using UiTests.Framework.WindowObjects;

    public static class OrganizationCreator
    {
        public static void Create(string name, string detailsPath)
        {
            TestApplication.MainWindow.SelectOrganizationsTabPage();
            TestApplication.MainWindow.OrganizationsTab.Add();

            TestApplication.NewOrganizationDialog
                           .SetName(name)
                           .SetDetailsPath(detailsPath)
                           .Save();
        }
    }
}