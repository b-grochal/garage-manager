using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public int UserId { get; set; }

        public UserNotFoundException(int userId)
        {
            UserId = userId;
        }

        public UserNotFoundException(string message, int userId) : base(message)
        {
            UserId = userId;
        }

        public UserNotFoundException(string message, Exception innerException, int userId) : base(message, innerException)
        {
            UserId = userId;
        }
    }
}
