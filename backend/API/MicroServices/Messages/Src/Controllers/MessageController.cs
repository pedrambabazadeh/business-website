using API.MicroServices.Messages.Interfaces;
using API.MicroServices.Messages.Mappers;
using API.MicroServices.Messages.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.MicroServices.Messages.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository messageRepo;

        public MessageController(IMessageRepository messageRepo)
        {
            this.messageRepo = messageRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MessageQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var messages = await messageRepo.GetAllAsync(query);
            var messageDto = messages.Select(m => m.ToMessageDto()).ToList();

            return Ok(messageDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var messageDto = await messageRepo.GetById(id);
            
            return messageDto is null ? NotFound("Message not found") : Ok(messageDto);
        }
    }
}