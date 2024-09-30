using API.Models;
using API.Data;
using API.MicroServices.Messages.Interfaces;
using API.MicroServices.Messages.Queries;
using Microsoft.EntityFrameworkCore;

namespace API.MicroServices.Messages.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext context;

        public MessageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Message>> GetAllAsync(MessageQuery query)
        {
            var messages = context.Messages.AsQueryable();

            if (query.CreatedOn.HasValue)
            {
                var createdOnDate = query.CreatedOn.Value;
                messages = messages.Where(m => m.CreatedOn >= createdOnDate);
            }

            if (query.CustomerID.HasValue)
                messages = messages.Where(m => m.CustomerID == query.CustomerID.Value);

            if (!string.IsNullOrEmpty(query.SortBy) &&
                query.SortBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                    messages = query.IsDescending ? messages.OrderByDescending(m => m.CreatedOn) : messages.OrderBy(m => m.CreatedOn);

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await messages.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public Task<Message?> GetById(int id)
        {
            return context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}