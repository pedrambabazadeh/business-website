using API.MicroServices.CMS.Src.DTOs;
using API.MicroServices.CMS.Src.Interfaces;
using API.MicroServices.CMS.Src.Mappers;
using API.MicroServices.CMS.Src.Queries;
using API.Extensions;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.MicroServices.CMS.Src.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IBlogRepository blogRepo;

        public BlogController(UserManager<AppUser> userManager, IBlogRepository blogRepo)
        {
            this.userManager = userManager;
            this.blogRepo = blogRepo;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateBlogDto createBlogDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await userManager.FindByNameAsync(username);

            if (appUser is null)
                return NotFound("User not found");

            var blogModel = createBlogDto.ToBlogFromCreateBlogDto(appUser);
            
            blogModel = await blogRepo.CreateAsync(blogModel);

            return Ok(blogModel.ToBlogDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BlogQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var blogs = await blogRepo.GetAllAsync(query);
            var blogsDto = blogs.Select(b => b.ToBlogDto()).ToList();

            return Ok(blogsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var blog = await blogRepo.GetByIdAsync(id);

            return blog is null ? NotFound("Blog not found") : Ok(blog.ToBlogDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogDto updateBlogDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingBlogModel = await blogRepo.GetByIdAsync(id);

            if (existingBlogModel is null)
                return NotFound("Blog not found");

            var username = User.GetUsername();
            var appUser = await userManager.FindByNameAsync(username);

            if (appUser is null)
                return NotFound("User not found");
            
            if (existingBlogModel.AppUserId != appUser.Id)
                return Unauthorized("Only author can edit this blog");

            var updatedBlogModel = updateBlogDto.ToBlogFromUpdateBlogDto();

            var editedBlogModel = await blogRepo.UpdateAsync(existingBlogModel, updatedBlogModel);

            return editedBlogModel is null ? NotFound("Blog not found") : Ok(editedBlogModel.ToBlogDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingBlogModel = await blogRepo.GetByIdAsync(id);

            if (existingBlogModel is null)
                return NotFound("Blog not found");

            var username = User.GetUsername();
            var appUser = await userManager.FindByNameAsync(username);

            if (appUser is null)
                return NotFound("User not found");
            
            if (existingBlogModel.AppUserId != appUser.Id)
                return Unauthorized("Only author can delete this blog");

            var deletedBlogModel = await blogRepo.DeleteAsync(existingBlogModel);

            return deletedBlogModel is null ? NotFound("Blog not found") : NoContent();
        }
    }
}