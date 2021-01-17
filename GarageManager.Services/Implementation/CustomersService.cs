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
    public class CustomersService : ICustomersService
    {
        private readonly GarageManagerDbContext context;

        public CustomersService(GarageManagerDbContext context)
        {
            this.context = context;
        }

        public async Task CreateCustomer(Customer cutsomer)
        {
            await context.Customers.AddAsync(cutsomer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customer = await context.Customers.FindAsync(customerId);
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }

        public async Task EditCustomer(Customer customer)
        {
            context.Customers.Update(customer);
            await context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await context.Customers.FindAsync(customerId);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers(CustomersListSearchCriteria customersListSearchCriteria)
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
