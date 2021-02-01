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
        private readonly IMessageBoxService messageBoxService;

        public ShowCreateUserViewCommand(INavigator navigator, IViewModelFactory viewModelFactory, IMessageBoxService messageBoxService)
        {
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
            this.messageBoxService = messageBoxService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                var createUserViewModel = viewModelFactory.CreateViewModel(ViewType.CreateUser);
                navigator.CurrentViewModel = createUserViewModel;
            }
            catch (Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unknown error occurred.");
            }
        }
    }
}
