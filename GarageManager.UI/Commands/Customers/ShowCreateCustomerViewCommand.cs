using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.Commands
{
    public class ShowCreateCustomerViewCommand : ICommand
    {
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowCreateCustomerViewCommand(INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BaseViewModel createUserViewModel = viewModelFactory.CreateViewModel(ViewType.CreateCustomer);
            navigator.CurrentViewModel = createUserViewModel;
        }
    }
}
