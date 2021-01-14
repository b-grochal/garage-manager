using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.Commands
{
    public class ShowCreateUserViewCommand : ICommand
    {
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;

        public ShowCreateUserViewCommand(INavigator navigator, IViewModelFactory viewModelFactory)
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
            var createUserViewModel = viewModelFactory.CreateViewModel(ViewType.CreateUser);
            navigator.CurrentViewModel = createUserViewModel;
        }
    }
}
