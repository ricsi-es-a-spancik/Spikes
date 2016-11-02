using LocalEntities.View;
using LocalEntities.ViewModel;
using Microsoft.Practices.Unity;
using NavigationWithPRISM.Infrastructure;
using Prism.Regions;

namespace LocalEntities
{
    public class LocalEntitiesModule : ModuleBase
    {
        public LocalEntitiesModule(IUnityContainer container, IRegionManager regionManager)
            : base (container, regionManager)
        {
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.LibrariesRegion, typeof(LocalItemsView));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<LocalItemsView>();
            Container.RegisterType<LocalItemsViewModel>();

            Container.RegisterType(typeof(object), typeof(LocalItemDetailsView), typeof(LocalItemDetailsView).FullName);
            Container.RegisterType<LocalItemDetailsView>();
        }
    }
}
