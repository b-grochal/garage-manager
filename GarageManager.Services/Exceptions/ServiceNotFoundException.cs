using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public int ServiceId { get; set; }

        public ServiceNotFoundException(int serviceId)
        {
            ServiceId = serviceId;
        }

        public ServiceNotFoundException(string message, int serviceId) : base(message)
        {
            ServiceId = serviceId;
        }

        public ServiceNotFoundException(string message, Exception innerException, int serviceId) : base(message, innerException)
        {
            ServiceId = serviceId;
        }
    }
}
