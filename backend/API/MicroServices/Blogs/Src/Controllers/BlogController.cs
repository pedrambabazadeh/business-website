using API.MicroServices.Blogs.DTOs;
using API.MicroServices.Blogs.Interfaces;
using API.MicroServices.Blogs.Mappers;
using API.MicroServices.Blogs.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.MicroServices.Blogs.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository blogRepo;

        public BlogController(IBlogRepository blogRepo)
        {
            this.blogRepo = blogRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogDto blogDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var blog = await blogRepo.CreateAsync(blogDto);

            return Ok(blog.ToBlogDto());
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogDto blogDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var blogModel =  await blogRepo.UpdateAsync(id, blogDto);

            return blogModel is null ? NotFound("Blog not found") : Ok(blogModel.ToBlogDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var blogModel = await blogRepo.DeleteAsync(id);

            return blogModel is null ? NotFound("Blog not found") : NoContent();
        }
    }
}