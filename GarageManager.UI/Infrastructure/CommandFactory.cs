using GarageManager.UI.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GarageManager.UI.Infrastructure
{
    public delegate TCommand CreateCommand<TCommand>() where TCommand : ICommand;

    public class CommandFactory : ICommandFactory
    {
        private readonly CreateCommand<LoginCommand> _createLoginCommand;
        private readonly CreateCommand<ShowHomePageCommand> _createShowHomePageCommand;
        private readonly CreateCommand<ShowUsersListCommand> _createShowUsersListCommand;

        public CommandFactory(CreateCommand<LoginCommand> createLoginCommand, CreateCommand<ShowHomePageCommand> createShowHomePageCommand, CreateCommand<ShowUsersListCommand> createShowUsersListCommand)
        {
            this._createLoginCommand = createLoginCommand;
            this._createShowHomePageCommand = createShowHomePageCommand;
            this._createShowUsersListCommand = createShowUsersListCommand;
        }

        public ICommand CreateViewModel(CommandType viewType)
        {
            switch (viewType)
            {
                case CommandType.Login:
                    return _createLoginCommand();
                case CommandType.ShowHomePage:
                    return _createShowHomePageCommand();
                case CommandType.ShowUsersList:
                    return _createShowUsersListCommand();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
