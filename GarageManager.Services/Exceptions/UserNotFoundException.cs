using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserName { get; set; }

        public UserNotFoundException(string username)
        {
            UserName = username;
        }

        public UserNotFoundException(string message, string username) : base(message)
        {
            UserName = username;
        }

        public UserNotFoundException(string message, Exception innerException, string username) : base(message, innerException)
        {
            UserName = username;
        }
    }
}
