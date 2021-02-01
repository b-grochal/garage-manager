using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Authenticator;
using GarageManager.UI.State.Navigator;
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
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<UsersListViewModel>>(services => () => CreateUsersListViewModel(services));
                services.AddSingleton<CreateViewModel<CreateUserViewModel>>(services => () => CreateCreateUserViewModel(services));
                services.AddSingleton<CreateViewModel<CustomersListViewModel>>(services => () => CreateCustomersListViewModel(services));
                services.AddSingleton<CreateViewModel<CreateCustomerViewModel>>(services => () => CreateCreateCustomerViewModel(services));
                services.AddSingleton<CreateViewModel<CustomerDetailsViewModel>>(services => () => CreateCustomerDetailsViewModel(services));
                services.AddSingleton<CreateViewModel<EditCustomerViewModel>>(services => () => CreateEditCustomerViewModel(services));
                services.AddSingleton<CreateViewModel<CarsListViewModel>>(services => () => CreateCarsListViewModel(services));
                services.AddSingleton<CreateViewModel<CreateCarViewModel>>(services => () => CreateCreateCarViewModel(services));
                services.AddSingleton<CreateViewModel<CarDetailsViewModel>>(services => () => CreateCarDetailsViewModel(services));
                services.AddSingleton<CreateViewModel<EditCarViewModel>>(services => () => CreateEditCarViewModel(services));
                services.AddSingleton<CreateViewModel<ServicesListViewModel>>(services => () => CreateServicesListViewModel(services));
                services.AddSingleton<CreateViewModel<CreateServiceViewModel>>(services => () => CreateCreateServiceViewModel(services));
                services.AddSingleton<CreateViewModel<ServiceDetailsViewModel>>(services => () => CreateServiceDetailsViewModel(services));
                services.AddSingleton<CreateViewModel<EditServiceViewModel>>(services => () => CreateEditServiceViewModel(services));

                services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            });

            return host;
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider serviceProvider)
        {
            return new LoginViewModel(
                serviceProvider.GetRequiredService<IAuthService>(),
                serviceProvider.GetRequiredService<IAuthenticator>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>());
        }

        private static UsersListViewModel CreateUsersListViewModel(IServiceProvider serviceProvider)
        {
            return new UsersListViewModel(
                serviceProvider.GetRequiredService<IUsersService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static CreateUserViewModel CreateCreateUserViewModel(IServiceProvider serviceProvider)
        {
            return new CreateUserViewModel(
                serviceProvider.GetRequiredService<IUsersService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static CustomersListViewModel CreateCustomersListViewModel(IServiceProvider serviceProvider)
        {
            return new CustomersListViewModel(
                serviceProvider.GetRequiredService<ICustomersService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static CreateCustomerViewModel CreateCreateCustomerViewModel(IServiceProvider serviceProvider)
        {
            return new CreateCustomerViewModel(
                serviceProvider.GetRequiredService<ICustomersService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static EditCustomerViewModel CreateEditCustomerViewModel(IServiceProvider serviceProvider)
        {
            return new EditCustomerViewModel(
                serviceProvider.GetRequiredService<ICustomersService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static CustomerDetailsViewModel CreateCustomerDetailsViewModel(IServiceProvider serviceProvider)
        {
            return new CustomerDetailsViewModel();
        }

        private static CarsListViewModel CreateCarsListViewModel(IServiceProvider serviceProvider)
        {
            return new CarsListViewModel(
                serviceProvider.GetRequiredService<ICarsService>(),
                serviceProvider.GetRequiredService<ICustomersService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static CreateCarViewModel CreateCreateCarViewModel(IServiceProvider serviceProvider)
        {
            return new CreateCarViewModel(
                serviceProvider.GetRequiredService<ICarsService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static EditCarViewModel CreateEditCarViewModel(IServiceProvider serviceProvider)
        {
            return new EditCarViewModel(
                serviceProvider.GetRequiredService<ICarsService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static CarDetailsViewModel CreateCarDetailsViewModel(IServiceProvider serviceProvider)
        {
            return new CarDetailsViewModel();
        }

        private static ServicesListViewModel CreateServicesListViewModel(IServiceProvider serviceProvider)
        {
            return new ServicesListViewModel(
                serviceProvider.GetRequiredService<IServicesService>(),
                serviceProvider.GetRequiredService<ICarsService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static CreateServiceViewModel CreateCreateServiceViewModel(IServiceProvider serviceProvider)
        {
            return new CreateServiceViewModel(
                serviceProvider.GetRequiredService<IServicesService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static EditServiceViewModel CreateEditServiceViewModel(IServiceProvider serviceProvider)
        {
            return new EditServiceViewModel(
                serviceProvider.GetRequiredService<IServicesService>(),
                serviceProvider.GetRequiredService<INavigator>(),
                serviceProvider.GetRequiredService<IViewModelFactory>(),
                serviceProvider.GetRequiredService<IMessageBoxService>());
        }

        private static ServiceDetailsViewModel CreateServiceDetailsViewModel(IServiceProvider serviceProvider)
        {
            return new ServiceDetailsViewModel();
        }
    }
}
