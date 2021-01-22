using GarageManager.Data.Entities;
using GarageManager.Services.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Interfaces
{
    public interface IServicesService
    {
        Task<IEnumerable<Service>> GetServices();
        Task<IEnumerable<Service>> GetServices(ServicesListSearchCriteria servicesListSearchCriteria);
        Task<Service> GetService(int serviceId);
        Task EditService(Service service);
        Task DeleteService(int serviceId);
        Task CreateService(Service service);
    }
}
