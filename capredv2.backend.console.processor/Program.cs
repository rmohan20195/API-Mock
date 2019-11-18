using System;
using System.IO;
using Autofac;
using capredv2.backend.console.processor.TopShelf;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;
using capredv2.backend.domain.DataContexts.UnitOfWork;
using capredv2.backend.domain.DataContexts.UnitOfWork.Interfaces;
using capredv2.backend.domain.Repositories;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services;
using capredv2.backend.domain.Services.Interfaces;
using Hangfire;
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Topshelf;

namespace capredv2.backend.console.processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
			//Log internal Hangfire stuff
			LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());

			Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

	        Log.Logger = new LoggerConfiguration()
		        .WriteTo.File("ConsoleApp.log")
		        .CreateLogger();

            //Use appsettings for Configuration
	        var configurationBuilder = new ConfigurationBuilder()
		        .SetBasePath(Directory.GetCurrentDirectory())
		        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true);
			var configuration = configurationBuilder.Build();

			Log.Information($"Read appSettings.json {DateTime.Now}");

			Log.Information($"Env {env}");

            //Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder();
                dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("CapREDV2SQLDatabase"),
                    b => b.MigrationsAssembly("capredv2.backend.domain"));

                return new CapRedV2Context(dbContextOptionsBuilder.Options);
            }).InstancePerLifetimeScope();

            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsSelf();
            containerBuilder.RegisterType<CoupaImporterRepository>().As<ICoupaImporterRepository>().AsSelf();
            containerBuilder.RegisterType<ProjectPurchaseOrderRepository>().As<IProjectPurchaseOrderRepository>().AsSelf();
            containerBuilder.RegisterType<ProjectRequisitionRepository>().As<IProjectRequisitionRepository>().AsSelf();
	        containerBuilder.RegisterType<ProjectInvoiceRepository>().As<IProjectInvoiceRepository>().AsSelf();
            containerBuilder.RegisterType<CoupaImporterService>().As<ICoupaImporterService>().AsSelf();
            var container = containerBuilder.Build();

            GlobalConfiguration.Configuration.UseAutofacActivator(container);

	        Log.Information($"Done with Autofac {DateTime.Now}");

	        Log.Information($"Connection String CapREDV2 {configuration.GetConnectionString("CapREDV2SQLDatabase")}");
	        Log.Information($"Connection String Hangfire {configuration.GetConnectionString("HangfireJobPersistence")}");

			// TopShelf Configuration
			HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<TopShelfConfig>(serviceConfig =>
                    {
                        serviceConfig.ConstructUsing(service => new TopShelfConfig(configuration.GetConnectionString("HangfireJobPersistence")));
                        serviceConfig.WhenStarted((service) =>service.Start());
                        serviceConfig.WhenStopped((service) => service.Stop());
                    });

	            Log.Information($"Created TopShelfConfig {DateTime.Now}");

				hostConfig.RunAsLocalSystem();
                hostConfig.StartAutomatically();

                hostConfig.SetServiceName("CapREDV2 Background Processor");
                hostConfig.SetDisplayName("CapREDV2 Background Processor");
                hostConfig.SetDescription("CapREDV2 Background Processor Description");

	            Log.Information($"Done with setting up Start and Stop of Service {DateTime.Now}");
			});
        }
    }
}
