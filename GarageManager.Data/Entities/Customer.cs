using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Data.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Car> Cars { get; set; }

        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}
