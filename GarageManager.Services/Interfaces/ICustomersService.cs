using GarageManager.Data.Entities;
using GarageManager.Services.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Customer>> GetCustomers(CustomersListSearchCriteria customersListSearchCriteria);
        Task<Customer> GetCustomer(int customerId);
        Task EditCustomer(Customer customer);
        Task DeleteCustomer(int customerId);
        Task CreateCustomer(Customer cutsomer);
    }
}
