using GarageManager.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.HostBuilders
{
    public static class AddViewsHostBuilderExtension
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }
    }
}
