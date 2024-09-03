using API.Models;
using API.MicroServices.Customers.Queries;

namespace API.MicroServices.Customers.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CustomerQuery query);
        Task<Customer?> GetById(int id);
    }
}