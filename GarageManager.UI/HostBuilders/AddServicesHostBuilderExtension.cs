using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.HostBuilders
{
    public static class AddServicesHostBuilderExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                //services.AddSingleton<IPasswordHasher, PasswordHasher>();

                //services.AddSingleton<IAuthenticationService, AuthenticationService>();
                //services.AddSingleton<IDataService<Account>, AccountDataService>();
                //services.AddSingleton<IAccountService, AccountDataService>();
                //services.AddSingleton<IStockPriceService, StockPriceService>();
                //services.AddSingleton<IBuyStockService, BuyStockService>();
                //services.AddSingleton<ISellStockService, SellStockService>();
                //services.AddSingleton<IMajorIndexService, MajorIndexService>();
            });

            return host;
        }
    }
}
