using GarageManager.Data.Entities;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace GarageManager.UI.ViewModels
{
    public class UsersListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; private set; }

        public UsersListViewModel()
        {

        }
    }
}
