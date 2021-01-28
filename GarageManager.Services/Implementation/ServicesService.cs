using GarageManager.Data.Context;
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
    public class ServicesService : IServicesService
    {
        private readonly GarageManagerDbContextFactory contextFactory;

        public ServicesService(GarageManagerDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task CreateService(Service service)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                await context.Services.AddAsync(service);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteService(int serviceId)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                Service service = await context.Services.FindAsync(serviceId);

                if (service == null)
                {
                    throw new ServiceNotFoundException(serviceId);
                }

                context.Services.Remove(service);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditService(Service service)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                context.Services.Update(service);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Service> GetService(int serviceId)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                Service service = await context.Services.FindAsync(serviceId);

                if (service == null)
                {
                    throw new ServiceNotFoundException(serviceId);
                }

                return service;
            }
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                return await context.Services.ToListAsync();
            }
        }

        public async Task<IEnumerable<Service>> GetServices(ServicesListSearchCriteria servicesListSearchCriteria)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                IQueryable<Service> queryable = context.Services.AsQueryable();

                if (!string.IsNullOrEmpty(servicesListSearchCriteria.Vin))
                {
                    queryable = queryable.Where(s => s.Car.Vin.Equals(servicesListSearchCriteria.Vin));
                }

                return await queryable.ToListAsync();
            }
        }
    }
}
