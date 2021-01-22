using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public int CustomerId { get; set; }

        public CustomerNotFoundException(int customerId)
        {
            CustomerId = customerId;
        }

        public CustomerNotFoundException(string message, int customerId) : base(message)
        {
            CustomerId = customerId;
        }

        public CustomerNotFoundException(string message, Exception innerException, int customerId) : base(message, innerException)
        {
            CustomerId = customerId;
        }
    }
}
