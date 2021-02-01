using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GarageManager.UI.Commands
{
    public class ShowHomeViewCommand : ICommand
    {
        private readonly INavigator navigator;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IMessageBoxService messageBoxService;

        public ShowHomeViewCommand(INavigator navigator, IViewModelFactory viewModelFactory)
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
            try
            {
                var homeViewModel = viewModelFactory.CreateViewModel(ViewType.Home);
                navigator.CurrentViewModel = homeViewModel;
            }
            catch(Exception)
            {
                messageBoxService.ShowErrorMessageBox("Error", "An unexpected error occurred.");
            }
        }
    }
}
