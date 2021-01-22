using GarageManager.Data.Context;
using GarageManager.Data.Entities;
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
    public class ServicesService : IServicesService
    {
        private readonly GarageManagerDbContext context;

        public ServicesService(GarageManagerDbContext context)
        {
            this.context = context;
        }

        public async Task CreateService(Service service)
        {
            await context.Services.AddAsync(service);
            await context.SaveChangesAsync();
        }

        public async Task DeleteService(int serviceId)
        {
            Service service = await context.Services.FindAsync(serviceId);
            context.Services.Remove(service);
            await context.SaveChangesAsync();
        }

        public async Task EditService(Service service)
        {
            context.Services.Update(service);
            await context.SaveChangesAsync();
        }

        public async Task<Service> GetService(int serviceId)
        {
            Service service = await context.Services.FindAsync(serviceId);
            return service;
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            return await context.Services.ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetServices(ServicesListSearchCriteria servicesListSearchCriteria)
        {
            IQueryable<Service> queryable = context.Services.AsQueryable();

            if(!string.IsNullOrEmpty(servicesListSearchCriteria.Vin))
            {
                queryable = queryable.Where(s => s.Car.Vin.Equals(servicesListSearchCriteria.Vin));
            }

            return await queryable.ToListAsync();
        }
    }
}
