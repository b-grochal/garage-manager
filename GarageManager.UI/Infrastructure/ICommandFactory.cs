using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.Infrastructure
{
    public interface ICommandFactory
    {
        ICommand CreateViewModel(CommandType viewType);
    }
}
