using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Exceptions
{
    public class InvalidUserNameException : Exception
    {
        public string UserName { get; set; }

        public InvalidUserNameException(string userId)
        {
            UserName = userId;
        }

        public InvalidUserNameException(string message, string userId) : base(message)
        {
            UserName = userId;
        }

        public InvalidUserNameException(string message, Exception innerException, string userId) : base(message, innerException)
        {
            UserName = userId;
        }
    }
}
