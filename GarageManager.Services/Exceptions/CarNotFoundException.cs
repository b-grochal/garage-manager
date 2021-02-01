using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Exceptions
{
    public class CarNotFoundException : Exception
    {
        public int CarId { get; set; }

        public CarNotFoundException(int carId)
        {
            CarId = carId;
        }

        public CarNotFoundException(string message, int carId) : base(message)
        {
            CarId = carId;
        }

        public CarNotFoundException(string message, Exception innerException, int carId) : base(message, innerException)
        {
            CarId = carId;
        }
    }
}
