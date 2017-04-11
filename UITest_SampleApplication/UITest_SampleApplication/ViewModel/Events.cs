﻿namespace UITest_SampleApplication.ViewModel
{
    using Prism.Events;

    using UITest_SampleApplication.Model;

    internal static class Events
    {
        public class CancelLoginRequested : PubSubEvent
        {
        }

        public class LoginRequested : PubSubEvent<UserCredentials>
        {
        }

        public class ReenterCredentialsRequested : PubSubEvent
        {
        }

        public class SignOutRequested : PubSubEvent
        {
        }

        public class ValidatingCredentialsRequested : PubSubEvent<UserCredentials>
        {
        }

        public class OpenNewOrganizationDialogRequested : PubSubEvent
        {
        }

        public class SaveNewOrganizationRequested : PubSubEvent<OrganizationViewModel>
        {
        }

        public class CloseActiveDialogRequested : PubSubEvent
        {
        }

        public class OpenCharacterDetailsFlyoutRequested : PubSubEvent
        {
        }

        public class OpenNewCharacterDialogRequested : PubSubEvent
        {
        }

        public class SaveNewCharacterRequested : PubSubEvent<CharacterViewModel>
        {
        }

        public class OpenNewVehicleDialogRequested : PubSubEvent
        {
        }

        public class SaveNewVehicleRequested : PubSubEvent<VehicleViewModel>
        {
        }
    }
}