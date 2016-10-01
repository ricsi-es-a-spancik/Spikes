using FlickrNet;
using Prism.Events;

namespace PhotosSearchWPF.ViewModel.Events
{
    public class PhotoSearchRequested : PubSubEvent<PhotoSearchOptions>
    {
    }
}
