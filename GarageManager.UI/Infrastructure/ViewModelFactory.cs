using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.Infrastructure
{
    public enum ViewType
    {
        Home,
        Login,
        UsersList,
        CreateUser,
        CustomersList,
        CreateCustomer,
        EditCustomer,
        CustomersDetails,
        CarsList,
        CreateCar,
        EditCar,
        CarDetails
    }

    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;

    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> createViewModel;
        private readonly CreateViewModel<LoginViewModel> createLoginViewModel;
        private readonly CreateViewModel<UsersListViewModel> createUsersListViewModel;
        private readonly CreateViewModel<CreateUserViewModel> createCreateUserViewModel;
        private readonly CreateViewModel<CustomersListViewModel> createCustomersListViewModel;
        private readonly CreateViewModel<CreateCustomerViewModel> createCreateCustomerViewModel;
        private readonly CreateViewModel<EditCustomerViewModel> createEditCustomerViewModel;
        private readonly CreateViewModel<CustomerDetailsViewModel> createCustomerDetailsViewModel;
        private readonly CreateViewModel<CarsListViewModel> createCarsListViewModel;
        private readonly CreateViewModel<CreateCarViewModel> createCreateCarViewModel;
        private readonly CreateViewModel<EditCarViewModel> createEditCarViewModel;
        private readonly CreateViewModel<CarDetailsViewModel> createCarDetailsViewModel;

        public ViewModelFactory(
            CreateViewModel<HomeViewModel> createViewModel, 
            CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<UsersListViewModel> createUsersListViewModel, 
            CreateViewModel<CreateUserViewModel> createCreateUserViewModel,
            CreateViewModel<CustomersListViewModel> createCustomersListViewModel,
            CreateViewModel<CreateCustomerViewModel> createCreateCustomerViewModel,
            CreateViewModel<EditCustomerViewModel> createEditCustomerViewModel,
            CreateViewModel<CustomerDetailsViewModel> createCustomerDetailsViewModel,
            CreateViewModel<CarsListViewModel> createCarsListViewModel,
            CreateViewModel<CreateCarViewModel> createCreateCarViewModel,
            CreateViewModel<EditCarViewModel> createEditCarViewModel,
            CreateViewModel<CarDetailsViewModel> createCarDetailsViewModel)
        {
            this.createViewModel = createViewModel;
            this.createLoginViewModel = createLoginViewModel;
            this.createUsersListViewModel = createUsersListViewModel;
            this.createCreateUserViewModel = createCreateUserViewModel;
            this.createCustomersListViewModel = createCustomersListViewModel;
            this.createCreateCustomerViewModel = createCreateCustomerViewModel;
            this.createEditCustomerViewModel = createEditCustomerViewModel;
            this.createCustomerDetailsViewModel = createCustomerDetailsViewModel;
            this.createCarsListViewModel = createCarsListViewModel;
            this.createCreateCarViewModel = createCreateCarViewModel;
            this.createEditCarViewModel = createEditCarViewModel;
            this.createCarDetailsViewModel = createCarDetailsViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return createViewModel();
                case ViewType.Login:
                    return createLoginViewModel();
                case ViewType.UsersList:
                    return createUsersListViewModel();
                case ViewType.CreateUser:
                    return createCreateUserViewModel();
                case ViewType.CustomersList:
                    return createCustomersListViewModel();
                case ViewType.CreateCustomer:
                    return createCreateCustomerViewModel();
                case ViewType.EditCustomer:
                    return createEditCustomerViewModel();
                case ViewType.CustomersDetails:
                    return createCustomerDetailsViewModel();
                case ViewType.CarsList:
                    return createCarsListViewModel();
                case ViewType.CreateCar:
                    return createCreateCarViewModel();
                case ViewType.EditCar:
                    return createEditCarViewModel();
                case ViewType.CarDetails:
                    return createCarDetailsViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
