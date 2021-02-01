using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string Username { get; set; }

        public InvalidPasswordException(string username)
        {
            Username = username;
        }

        public InvalidPasswordException(string message, string username) : base(message)
        {
            Username = username;
        }

        public InvalidPasswordException(string message, Exception innerException, string username) : base(message, innerException)
        {
            Username = username;
        }
    }
}
