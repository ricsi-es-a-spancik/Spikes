using Microsoft.Practices.Unity;
using NavigationWithPRISM.Infrastructure;
using Prism.Regions;
using RemoteSearch.View;
using RemoteSearch.ViewModel;

namespace RemoteSearch
{
    public class RemoteSearchModule : ModuleBase
    {
        public RemoteSearchModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {
        }

        protected override void InitializeModule()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.SearchRegion, typeof(SearchOptionsView));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<SearchOptionsView>();
            Container.RegisterType<SearchOptionsViewModel>();

            Container.RegisterType(typeof(object), typeof(SearchResultsView), typeof(SearchResultsView).FullName);
            Container.RegisterType<SearchResultsViewModel>();

            Container.RegisterType(typeof(object), typeof(RemoteItemDetailsView), typeof(RemoteItemDetailsView).FullName);
            Container.RegisterType<RemoteItemDetailsViewModel>();
        }
    }
}
