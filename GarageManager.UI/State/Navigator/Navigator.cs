using GarageManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.UI.State.Navigator
{
    public class Navigator : INavigator
    {
        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel 
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
