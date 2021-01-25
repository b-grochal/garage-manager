﻿using GarageManager.Data.Context;
using GarageManager.Data.Entities;
using GarageManager.Services.Exceptions;
using GarageManager.Services.Interfaces;
using GarageManager.Services.SearchCriteria;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Implementation
{
    public class CarsService : ICarsService
    {
        private readonly GarageManagerDbContext context;

        public CarsService(GarageManagerDbContext context)
        {
            this.context = context;
        }

        public async Task CreateCar(Car car)
        {
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCar(int carId)
        {
            var car = await context.Cars.FindAsync(carId);

            if (car == null)
            {
                throw new CarNotFoundException(carId);
            }

            context.Cars.Remove(car);
            await context.SaveChangesAsync();
        }

        public async Task EditCar(Car car)
        {
            context.Cars.Update(car);
            await context.SaveChangesAsync();
        }

        public async Task<Car> GetCar(int carId)
        {
            var car = await context.Cars.FindAsync(carId);

            if (car == null)
            {
                throw new CarNotFoundException(carId);
            }

            return car;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await context.Cars.ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCars(CarsListSearchCriteria carsListSearchCriteria)
        {
            var queryable = context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(carsListSearchCriteria.Vin))
            {
                queryable = queryable.Where(c => c.Vin.Equals(carsListSearchCriteria.Vin));
            }

            return await queryable.ToListAsync();
        }
    }
}
