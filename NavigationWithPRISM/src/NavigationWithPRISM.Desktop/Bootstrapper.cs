using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using RemoteSearch;
using RemoteSearchService;
using LocalEntities;

namespace NavigationWithPRISM.Desktop
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(RemoteSearchModule));
            catalog.AddModule(typeof(RemoteSearchServiceModule));
            catalog.AddModule(typeof(LocalEntitiesModule));
            return catalog;
        }
    }
}
