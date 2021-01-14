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
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public ShowHomeViewCommand(INavigator navigator, IViewModelFactory viewModelFactory)
        {
            this._navigator = navigator;
            this._viewModelFactory = viewModelFactory;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var homeViewModel = _viewModelFactory.CreateViewModel(ViewType.Home);
            _navigator.CurrentViewModel = homeViewModel;
        }
    }
}
