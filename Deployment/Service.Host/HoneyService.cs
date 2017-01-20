using Service.Implementation;
using Service.Interfaces;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;

namespace Service.Host
{
    public partial class HoneyService : ServiceBase
    {
        ServiceHost _host;

        public HoneyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_host != null)
            {
                _host.Close();
            }

            //Create a URI to serve as the base address
            var httpUrl = new Uri("http://localhost:8080/HoneyService");

            //Create ServiceHost
            _host = new ServiceHost(typeof(HoneyServiceImpl), httpUrl);

            //Add a service endpoint
            _host.AddServiceEndpoint(typeof(IHoneyService), new WSHttpBinding(), "");

            //Enable metadata exchange
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            _host.Description.Behaviors.Add(smb);

            //Start the Service
            _host.Open();
        }

        protected override void OnStop()
        {
            if (_host != null)
            {
                _host.Close();
                _host = null;
            }
        }
    }
}
