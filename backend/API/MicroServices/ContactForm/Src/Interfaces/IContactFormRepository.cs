using API.MicroServices.ContactForm.Src.DTOs;
using API.Models;

namespace API.MicroServices.ContactForm.Src.Interfaces
{
    public interface IContactFormRepository
    {
        Task<Customer> CreateCustomerAsync(ContactFormDto contactFormDto);
        Task<Message> CreateMessageAsync(ContactFormDto contactFormDto, int id);
    }
}