using API.Models;
using API.MicroServices.Blogs.DTOs;
using API.MicroServices.Blogs.Queries;

namespace API.MicroServices.Blogs.Interfaces
{
    public interface IBlogRepository
    {
        Task<Blog> CreateAsync(CreateBlogDto blogDto);
        Task<List<Blog>> GetAllAsync(BlogQuery query);
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog?> UpdateAsync(int id, UpdateBlogDto blogDto);
        Task<Blog?> DeleteAsync(int id); 
    }
}