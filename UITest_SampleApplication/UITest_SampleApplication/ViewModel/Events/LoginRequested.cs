﻿namespace UITest_SampleApplication.ViewModel.Events
{
    using Prism.Events;

    using UITest_SampleApplication.Model;

    public class LoginRequested : PubSubEvent<UserCredentials>
    {
    }
}
