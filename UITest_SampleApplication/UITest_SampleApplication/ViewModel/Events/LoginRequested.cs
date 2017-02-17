using Microsoft.Practices.Prism.PubSubEvents;
using UITest_SampleApplication.Model;

namespace UITest_SampleApplication.ViewModel.Events
{
    public class LoginRequested : PubSubEvent<UserCredentials>
    {
    }
}
