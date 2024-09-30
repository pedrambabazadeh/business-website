using API.Models;
using API.MicroServices.Messages.DTOs;

namespace API.MicroServices.Messages.Mappers
{
    public static class MessageMappers
    {
        public static MessageDto ToMessageDto(this Message messageModel)
        {
            return new MessageDto {
                Id = messageModel.Id,
                Content = messageModel.Content,
                CreatedOn = messageModel.CreatedOn,
                CustomerID = messageModel.CustomerID
            };
        }
    }
}