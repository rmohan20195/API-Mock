using System;
using System.Collections.Generic;
using System.Text;
using Topshelf;

namespace capredv2.backend.console.processor.TopShelf
{
    public static class ConfigureTopShelf
    {
        //public static void ConfigureService(string connectionString)
        //{
        //    HostFactory.Run(hostConfig =>
        //        {
        //            hostConfig.Service<TopShelfConfig>(serviceConfig =>
        //                {
        //                    serviceConfig.ConstructUsing<TopShelfConfig>(service => new TopShelfConfig(connectionString));
        //                    serviceConfig.WhenStarted((service, hostControl) => service.Start(hostControl));
        //                    serviceConfig.WhenStopped((service, hostControl) => service.Stop(hostControl));
        //                });

        //            hostConfig.RunAsLocalSystem();
        //            hostConfig.StartAutomatically();

        //            hostConfig.SetServiceName("CapREDV2 Background Processor");
        //            hostConfig.SetDisplayName("CapREDV2 Background Processor");
        //            hostConfig.SetDescription("CapREDV2 Background Processor Description");
        //        });
        //}
    }
}
