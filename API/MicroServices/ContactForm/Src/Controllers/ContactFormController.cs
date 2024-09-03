using API.MicroServices.ContactForm.Src.DTOs;
using API.MicroServices.ContactForm.Src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.MicroServices.ContactForm.Src.Controllers
{
    [Route("/api/contact")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormRepository contactFormRepo;

        public ContactFormController(IContactFormRepository contactFormRepo)
        {
            this.contactFormRepo = contactFormRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] ContactFormDto contactFormDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerModel = await contactFormRepo.CreateCustomerAsync(contactFormDto);
            
            await contactFormRepo.CreateMessageAsync(contactFormDto, customerModel.Id);

            return Created("/api/contact/success", contactFormDto);
        }
    }
}