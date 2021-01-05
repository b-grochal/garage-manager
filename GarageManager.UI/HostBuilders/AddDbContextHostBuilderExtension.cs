using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.HostBuilders
{
    public static class AddDbContextHostBuilderExtension
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                //string connectionString = context.Configuration.GetConnectionString("sqlite");
                //Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

                //services.AddDbContext<SimpleTraderDbContext>(configureDbContext);
                //services.AddSingleton<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
