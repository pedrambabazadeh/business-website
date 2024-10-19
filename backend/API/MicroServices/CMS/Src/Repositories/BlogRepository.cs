using API.Data;
using API.Models;
using API.MicroServices.CMS.Src.Interfaces;
using API.MicroServices.CMS.Src.Queries;
using Microsoft.EntityFrameworkCore;

namespace API.MicroServices.CMS.Src.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext context;

        public BlogRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Blog> CreateAsync(Blog blogModel)
        {
            await context.Blogs.AddAsync(blogModel);
            await context.SaveChangesAsync();

            return blogModel;
        }

        public async Task<List<Blog>> GetAllAsync(BlogQuery query)
        {
            var blogs = context.Blogs.AsQueryable();

            if (query.Cat.HasValue)
                blogs = blogs.Where(b => b.Category == query.Cat.Value);

            if (!string.IsNullOrWhiteSpace(query.Author))
                blogs = blogs.Where(b => b.Author.Contains(query.Author));

            if (!string.IsNullOrWhiteSpace(query.Title))
                blogs = blogs.Where(b => b.Title.Contains(query.Title));

            if (!string.IsNullOrEmpty(query.SortBy) &&
                query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    blogs = query.IsDescending ? blogs.OrderByDescending(b => b.Title): blogs.OrderBy(b => b.Title);
                }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await blogs.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog?> UpdateAsync(Blog existingBlogModel, Blog updatedBlogModel)
        {
            existingBlogModel.Author = existingBlogModel.Author;
            existingBlogModel.Category = existingBlogModel.Category;
            existingBlogModel.Title = updatedBlogModel.Title;
            existingBlogModel.Content = updatedBlogModel.Content;
            existingBlogModel.CreatedOn = existingBlogModel.CreatedOn;
            existingBlogModel.ModifiedOn = updatedBlogModel.ModifiedOn;

            await context.SaveChangesAsync();

            return existingBlogModel;
        }

        public async Task<Blog?> DeleteAsync(Blog existingBlogModel)
        {
            context.Blogs.Remove(existingBlogModel);
            await context.SaveChangesAsync();

            return existingBlogModel;
        }
    }
}