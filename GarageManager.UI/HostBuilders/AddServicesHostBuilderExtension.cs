using GarageManager.Data.Entities;
using GarageManager.Services.Implementation;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
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
                services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
                services.AddSingleton<IAuthService, AuthService>();
                services.AddSingleton<IUsersService, UsersService>();
                services.AddSingleton<ICustomersService, CustomersService>();
                services.AddSingleton<ICarsService, CarsService>();
                services.AddSingleton<IServicesService, ServicesService>();
                services.AddSingleton<IMessageBoxService, MessageBoxService>();
                //services.AddSingleton<IBuyStockService, BuyStockService>();
                //services.AddSingleton<ISellStockService, SellStockService>();
                //services.AddSingleton<IMajorIndexService, MajorIndexService>();
            });

            return host;
        }
    }
}
