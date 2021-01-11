using GarageManager.Data.Entities;
using GarageManager.Services.Interfaces;
using GarageManager.UI.Infrastructure;
using GarageManager.UI.State.Navigator;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace GarageManager.UI.ViewModels
{
    public class UsersListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UsersListViewModel(IUsersService usersService, INavigator navigator, IViewModelFactory viewModelFactory)
        {

        }
    }
}
