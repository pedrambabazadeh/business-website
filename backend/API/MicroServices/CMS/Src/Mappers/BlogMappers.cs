using API.MicroServices.CMS.Src.DTOs;
using API.Models;

namespace API.MicroServices.CMS.Src.Mappers
{
    public static class BlogMappers
    {
        public static BlogDto ToBlogDto(this Blog blogModel)
        {
            return new BlogDto
            {
                Id = blogModel.Id,
                Author = blogModel.Author,
                Category = blogModel.Category,
                Title = blogModel.Title,
                Content = blogModel.Content,
                CreatedOn = blogModel.CreatedOn,
                ModifiedOn = blogModel.ModifiedOn
            };
        }
        
        public static Blog ToBlogFromCreateBlogDto(this CreateBlogDto createBlogDto, AppUser appUser)
        {
            return new Blog
            {
                Author = $"{appUser.FirstName} {appUser.LastName}",
                Category = appUser.Category,
                Title = createBlogDto.Title,
                Content = createBlogDto.Content,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                AppUserId = appUser.Id,
                AppUser = appUser
            };
        }

        public static Blog ToBlogFromUpdateBlogDto(this UpdateBlogDto updateBlogDto)
        {
            return new Blog
            {
                Title = updateBlogDto.Title,
                Content = updateBlogDto.Content,
                ModifiedOn = DateTime.Now
            };
        }
    }
}