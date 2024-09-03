using API.Models;
using API.MicroServices.Blogs.DTOs;

namespace API.MicroServices.Blogs.Mappers
{
    public static class BlogMappers
    {
        public static BlogDto ToBlogDto(this Blog blogModel)
        {
            return new BlogDto
            {
                Id = blogModel.Id,
                Author = blogModel.Author,
                Cat = blogModel.Cat,
                Title = blogModel.Title,
                Content = blogModel.Content,
                CreatedOn = blogModel.CreatedOn,
                ModifiedOn = blogModel.ModifiedOn
            };
        }
        
        public static Blog ToBlogFromCreateBlogDto(this CreateBlogDto blogDto)
        {
            return new Blog
            {
                Author = blogDto.Author,
                Cat = blogDto.Cat,
                Title = blogDto.Title,
                Content = blogDto.Content,
                CreatedOn = blogDto.CreatedOn,
                ModifiedOn = blogDto.ModifiedOn
            };
        }
    }
}