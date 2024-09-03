using API.Data;
using API.Models;
using API.MicroServices.ContactForm.Src.DTOs;
using API.MicroServices.ContactForm.Src.Interfaces;
using API.MicroServices.ContactForm.Src.Mappers;
using Microsoft.EntityFrameworkCore;

namespace API.MicroServices.ContactForm.Src.Repositories
{
    public class ContactFormRepository : IContactFormRepository
    {
        private readonly ApplicationDbContext context;

        public ContactFormRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Customer> CreateCustomerAsync(ContactFormDto contactFormDto)
        {
            var customerModel = contactFormDto.ToCustomerFromContactFormDto();
            var existingCustomer = await context.Customers.FirstOrDefaultAsync(c => c.CompanyName == customerModel.CompanyName);

            if (existingCustomer is not null)
                return existingCustomer;

            await context.Customers.AddAsync(customerModel);
            await context.SaveChangesAsync();

            return customerModel;
        }

        public async Task<Message> CreateMessageAsync(ContactFormDto contactFormDto, int id)
        {
            var messageModel = contactFormDto.ToMessageFromContactFormDto(id);

            await context.Messages.AddAsync(messageModel);
            await context.SaveChangesAsync();

            return messageModel;
        }
    }
}