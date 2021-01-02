using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Data.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cosr { get; set; }
        public DateTime DateOfService { get; set; }
        public Car Car { get; set; }
    }
}
