using API.Data;
using API.Models;
using API.MicroServices.Blogs.DTOs;
using API.MicroServices.Blogs.Interfaces;
using API.MicroServices.Blogs.Mappers;
using API.MicroServices.Blogs.Queries;
using Microsoft.EntityFrameworkCore;

namespace API.MicroServices.Blogs.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext context;

        public BlogRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Blog> CreateAsync(CreateBlogDto blogDto)
        {
            var blogModel = blogDto.ToBlogFromCreateBlogDto();

            await context.Blogs.AddAsync(blogModel);
            await context.SaveChangesAsync();

            return blogModel;
        }

        public async Task<List<Blog>> GetAllAsync(BlogQuery query)
        {
            var blogs = context.Blogs.AsQueryable();

            if (query.Cat.HasValue)
                blogs = blogs.Where(b => b.Cat == query.Cat.Value);

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

        public async Task<Blog?> UpdateAsync(int id, UpdateBlogDto blogDto)
        {
            var existingBlog = await context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBlog is null)
                return null;

            existingBlog.Author = existingBlog.Author;
            existingBlog.Cat = blogDto.Cat;
            existingBlog.Title = blogDto.Title;
            existingBlog.Content = blogDto.Content;
            existingBlog.CreatedOn = existingBlog.CreatedOn;
            existingBlog.ModifiedOn = blogDto.ModifiedOn;

            await context.SaveChangesAsync();

            return existingBlog;
        }

        public async Task<Blog?> DeleteAsync(int id)
        {
            var existingBlog = await context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (existingBlog is null)
                return null;

            context.Blogs.Remove(existingBlog);
            await context.SaveChangesAsync();

            return existingBlog;
        }
    }
}