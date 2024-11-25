using API.Models;
using API.MicroServices.Messages.Queries;

namespace API.MicroServices.Messages.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllAsync(MessageQuery query);
        Task<Message?> GetById(int id);
    }
}