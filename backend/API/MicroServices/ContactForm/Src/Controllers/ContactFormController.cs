using API.MicroServices.ContactForm.Src.DTOs;
using API.MicroServices.ContactForm.Src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.MicroServices.ContactForm.Src.Controllers
{
    [Route("/api/contact_form")]
    [ApiController]
    public class ContactFormController(IContactFormRepository contactFormRepo) : ControllerBase
    {
        private readonly IContactFormRepository contactFormRepo = contactFormRepo;

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] ContactFormDto contactFormDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerModel = await contactFormRepo.CreateCustomerAsync(contactFormDto);
            
            await contactFormRepo.CreateMessageAsync(contactFormDto, customerModel.Id);
            
            return Created("/api/contact/submit/success", contactFormDto);
        }
    }
}