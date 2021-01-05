using GarageManager.UI.Infrastructure;
using GarageManager.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.HostBuilders
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                //services.AddSingleton(CreateHomeViewModel);
                services.AddSingleton<HomeViewModel>();
                //services.AddSingleton<BuyViewModel>();
                //services.AddSingleton<SellViewModel>();
                //services.AddSingleton<AssetSummaryViewModel>();
                //services.AddSingleton<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                //services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services => () => services.GetRequiredService<PortfolioViewModel>());
                //services.AddSingleton<CreateViewModel<BuyViewModel>>(services => () => services.GetRequiredService<BuyViewModel>());
                //services.AddSingleton<CreateViewModel<SellViewModel>>(services => () => services.GetRequiredService<SellViewModel>());
                //services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                //services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));

                //services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();

                //services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                //services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                //services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            });

            return host;
        }
    }
}
