using GarageManager.Data.Entities;
using GarageManager.Services.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Interfaces
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetCars();
        Task<IEnumerable<Car>> GetCars(CarsListSearchCriteria customersListSearchCriteria);
        Task<Car> GetCar(int carId);
        Task EditCar(Car car);
        Task DeleteCar(int carId);
        Task CreateCar(Car car);
    }
}
