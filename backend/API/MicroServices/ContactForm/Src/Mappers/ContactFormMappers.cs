using API.MicroServices.ContactForm.Src.DTOs;
using API.Models;

namespace API.MicroServices.ContactForm.Src.Mappers
{
    public static class ContactFormMappers
    {
        public static Customer ToCustomerFromContactFormDto(this ContactFormDto contactFormDto)
        {
            return new Customer {
                FirstName = contactFormDto.FirstName,
                LastName = contactFormDto.LastName,
                Email = contactFormDto.Email,
                CompanyName = contactFormDto.CompanyName,
                WebsiteUrl = contactFormDto.WebsiteUrl,
                CreatedOn = contactFormDto.CreatedOn
            };
        }

        public static Message ToMessageFromContactFormDto(this ContactFormDto contactFormDto, int id)
        {
            return new Message {
                CustomerID = id,
                Content = contactFormDto.Content,
                CreatedOn = contactFormDto.CreatedOn
            };
        }
    }
}