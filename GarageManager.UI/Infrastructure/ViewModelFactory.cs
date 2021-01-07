using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.Infrastructure
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;

    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public ViewModelFactory(CreateViewModel<HomeViewModel> createViewModel, CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            this._createViewModel = createViewModel;
            this._createLoginViewModel = createLoginViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
