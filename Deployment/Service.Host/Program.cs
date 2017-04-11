﻿using System.ServiceProcess;

namespace Service.Host
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new HoneyService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}