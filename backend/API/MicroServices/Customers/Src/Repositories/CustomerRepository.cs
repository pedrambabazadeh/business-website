using API.Data;
using API.Models;
using API.MicroServices.Customers.Interfaces;
using API.MicroServices.Customers.Queries;
using Microsoft.EntityFrameworkCore;

namespace API.MicroServices.Customers.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Customer>> GetAllAsync(CustomerQuery query)
        {
            var customers = context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.FirstName))
                customers = customers.Where(c => c.FirstName.Contains(query.FirstName));

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
                customers = customers.Where(c => c.CompanyName.Contains(query.CompanyName));

            if (!string.IsNullOrEmpty(query.SortBy) &&
                query.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase))
                {
                    customers = query.IsDescending ? customers.OrderByDescending(c => c.CompanyName): customers.OrderBy(c => c.CompanyName);
                }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await customers.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Customer?> GetById(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}