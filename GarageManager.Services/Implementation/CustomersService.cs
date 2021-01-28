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
    public class CustomersService : ICustomersService
    {
        private readonly GarageManagerDbContextFactory contextFactory;

        public CustomersService(GarageManagerDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task CreateCustomer(Customer cutsomer)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                await context.Customers.AddAsync(cutsomer);
                await context.SaveChangesAsync();

            }
            
        }

        public async Task DeleteCustomer(int customerId)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                var customer = await context.Customers.FindAsync(customerId);

                if (customer == null)
                {
                    throw new CustomerNotFoundException(customerId);
                }

                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
            
        }

        public async Task EditCustomer(Customer customer)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                context.Customers.Update(customer);
                await context.SaveChangesAsync();
            }
            
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                var customer = await context.Customers.FindAsync(customerId);

                if (customer == null)
                {
                    throw new CustomerNotFoundException(customerId);
                }

                return customer;
            }
            
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                return await context.Customers.ToListAsync();
            }
            
        }

        public async Task<IEnumerable<Customer>> GetCustomers(CustomersListSearchCriteria customersListSearchCriteria)
        {
            using (GarageManagerDbContext context = contextFactory.CreateDbContext())
            {
                var queryable = context.Customers.AsQueryable();

                if (!string.IsNullOrEmpty(customersListSearchCriteria.FirstName))
                {
                    queryable = queryable.Where(c => c.FirstName.Equals(customersListSearchCriteria.FirstName));
                }

                if (!string.IsNullOrEmpty(customersListSearchCriteria.LastName))
                {
                    queryable = queryable.Where(c => c.LastName.Equals(customersListSearchCriteria.LastName));
                }

                return await queryable.ToListAsync();
            }
            
        }
    }
}
