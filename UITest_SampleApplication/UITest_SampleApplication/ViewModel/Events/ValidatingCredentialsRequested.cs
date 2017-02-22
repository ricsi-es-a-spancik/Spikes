namespace UITest_SampleApplication.ViewModel.Events
{
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class ValidatingCredentialsRequested : PubSubEvent<UserCredentials>
    {
    }
}