using Business;
using Prism.Events;

namespace NavigationWithPRISM.Infrastructure.Events
{
    public class DownloadRemoteItemRequested : PubSubEvent<RemoteItem>
    {
    }
}
