using Business;
using NavigationWithPRISM.Infrastructure;
using NavigationWithPRISM.Infrastructure.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System;
using LocalEntities.View;

namespace LocalEntities.ViewModel
{
    public class LocalItemsViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        private ObservableCollection<LocalItem> _localItems;

        public ObservableCollection<LocalItem> LocalItems
        {
            get { return _localItems; }
            set { SetProperty(ref _localItems, value); }
        }

        public ICommand SeeLocalItemDetails { get; private set; }

        public LocalItemsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<DownloadRemoteItemRequested>().Subscribe(OnDownloadRemoteItemRequested, ThreadOption.UIThread);

            LocalItems = new ObservableCollection<LocalItem>();
            SeeLocalItemDetails = new DelegateCommand<LocalItem>(OnSeeLocalItemDetails);
        }

        private void OnDownloadRemoteItemRequested(RemoteItem remoteItem)
        {
            var localItem = new LocalItem
            {
                Id = remoteItem.Id,
                Content = remoteItem.Content,
                LocalProperty = new string(remoteItem.Content.Reverse().ToArray())
            };

            LocalItems.Add(localItem);
        }

        private void OnSeeLocalItemDetails(LocalItem localItem)
        {
            var parameters = new NavigationParameters();
            parameters.Add("LocalItem", localItem);
            var uri = new Uri(typeof(LocalItemDetailsView).FullName, UriKind.Relative);
            _regionManager.RequestNavigate(RegionNames.ContentRegion, uri, parameters);
        }
    }
}
