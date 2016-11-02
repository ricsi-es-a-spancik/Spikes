using Microsoft.Practices.Unity;
using NavigationWithPRISM.Infrastructure;
using NavigationWithPRISM.Infrastructure.ServiceInterfaces;
using Prism.Regions;

namespace RemoteSearchService
{
    public class RemoteSearchServiceModule : ModuleBase
    {
        public RemoteSearchServiceModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {
        }

        protected override void InitializeModule()
        {
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IRemoteSearchService, RemoteSearchServiceImpl>(new ContainerControlledLifetimeManager());
        }
    }
}
