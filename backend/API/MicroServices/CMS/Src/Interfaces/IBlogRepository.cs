using API.Models;
using API.MicroServices.CMS.Src.Queries;

namespace API.MicroServices.CMS.Src.Interfaces
{
    public interface IBlogRepository
    {
        Task<Blog> CreateAsync(Blog blogModel);
        Task<List<Blog>> GetAllAsync(BlogQuery query);
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog?> UpdateAsync(Blog existingBlogModel, Blog updatedBlogModel);
        Task<Blog?> DeleteAsync(Blog existingBlogModel);
    }
}