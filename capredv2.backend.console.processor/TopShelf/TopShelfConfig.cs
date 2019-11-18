using System;
using Hangfire;
using Hangfire.SqlServer;
using Serilog;


namespace capredv2.backend.console.processor.TopShelf
{
    public class TopShelfConfig
    {
        private readonly string _connectionString;
        private BackgroundJobServer _backgroundJobServer;

        public TopShelfConfig(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
			Log.Information($"In TopShelfConfig.cs - connection string {connectionString}");
        }


        public void Start()
        {
	        Log.Information("In TopShelfConfig.cs - about to start service");
			var backgroundJobServerOptions = new BackgroundJobServerOptions
            {
                ServerName = "Windows Service",
            };

            _backgroundJobServer = new BackgroundJobServer(backgroundJobServerOptions, new SqlServerStorage(_connectionString));

	        Log.Information("In TopShelfConfig.cs - done with starting service");
        }

        public void Stop()
        {
            _backgroundJobServer.Dispose();
			Log.Information("In TopShelfConfig.cs - stopping service");
        }
    }
}
