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

        public ViewModelFactory(
            CreateViewModel<HomeViewModel> createViewModel, 
            CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<UsersListViewModel> createUsersListViewModel, 
            CreateViewModel<CreateUserViewModel> createCreateUserViewModel,
            CreateViewModel<CustomersListViewModel> createCustomersListViewModel,
            CreateViewModel<CreateCustomerViewModel> createCreateCustomerViewModel,
            CreateViewModel<EditCustomerViewModel> createEditCustomerViewModel,
            CreateViewModel<CustomerDetailsViewModel> createCustomerDetailsViewModel)
        {
            this.createViewModel = createViewModel;
            this.createLoginViewModel = createLoginViewModel;
            this.createUsersListViewModel = createUsersListViewModel;
            this.createCreateUserViewModel = createCreateUserViewModel;
            this.createCustomersListViewModel = createCustomersListViewModel;
            this.createCreateCustomerViewModel = createCreateCustomerViewModel;
            this.createEditCustomerViewModel = createEditCustomerViewModel;
            this.createCustomerDetailsViewModel = createCustomerDetailsViewModel;
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
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
