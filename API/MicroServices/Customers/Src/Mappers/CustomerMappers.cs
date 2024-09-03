using API.Models;
using API.MicroServices.Customers.DTOs;

namespace API.MicroServices.Customers.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            return new CustomerDto {
                Id = customerModel.Id,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Email = customerModel.Email,
                CompanyName = customerModel.CompanyName
            };
        }
    }
}