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
        CreateUser
    }

    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;

    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<UsersListViewModel> createUsersListViewModel;
        private readonly CreateViewModel<CreateUserViewModel> createCreateUserViewModel;

        public ViewModelFactory(
            CreateViewModel<HomeViewModel> createViewModel, 
            CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<UsersListViewModel> createUsersListViewModel, 
            CreateViewModel<CreateUserViewModel> createCreateUserViewModel)
        {
            this._createViewModel = createViewModel;
            this._createLoginViewModel = createLoginViewModel;
            this.createUsersListViewModel = createUsersListViewModel;
            this.createCreateUserViewModel = createCreateUserViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.UsersList:
                    return createUsersListViewModel();
                case ViewType.CreateUser:
                    return createCreateUserViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
