using GarageManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

                string connectionString = context.Configuration.GetConnectionString("Default");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseLazyLoadingProxies().UseSqlServer(connectionString);

                services.AddDbContext<GarageManagerDbContext>(configureDbContext);
            });

            return host;
        }
    }
}
