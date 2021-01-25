using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Data.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Vin { get; set; }
        public string RegistrationNumber { get; set; }
        public string FuelType { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Service> Services{ get; set; }

        public string FullName
        {
            get
            {
                return $"{this.Brand} {this.Model}";
            }
        }
    }
}
