using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using innoStarkAssignment.Api.Resources;
using innoStarkAssignment.Api.Validators;
using innoStarkAssignment.Core.Model;
using innoStarkAssignment.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace innoStarkAssignment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            this._mapper = mapper;
            this._blogService = blogService;
        }

        //Get api/blogs
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetAllBlogs()
        {
            var blogs = await _blogService.GetAllWithCategory();
            var blogResources = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogResource>>(blogs);

            return Ok(blogResources);
            
        }

        //Get api/blog/1
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogResource>> GetBlogById(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            var blogResource = _mapper.Map<Blog, BlogResource>(blog);

            return Ok(blogResource);
        }

        // POST api/blog
        [HttpPost("")]
        public async Task<ActionResult<BlogResource>> CreateBlog([FromBody] SaveBlogResource saveBlogResource)
        {
            var validator = new SaveBlogResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBlogResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);  

            var blogToCreate = _mapper.Map<SaveBlogResource, Blog>(saveBlogResource);

            var newBlog = await _blogService.CreateBlog(blogToCreate);

            var blog = await _blogService.GetBlogById(newBlog.Id);

            var blogResource = _mapper.Map<Blog, BlogResource>(blog);

            return Ok(blogResource);
        }

        // PUT api/blog/1
        [HttpPut("{id}")]
        public async Task<ActionResult<BlogResource>> UpdateBlog(int id, [FromBody] SaveBlogResource saveBlogResource)
        {
            var validator = new SaveBlogResourceValidator();
            var validationResult = await validator.ValidateAsync(saveBlogResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);  

            var blogToBeUpdate = await _blogService.GetBlogById(id);

            if (blogToBeUpdate == null)
                return NotFound();

            var blog = _mapper.Map<SaveBlogResource, Blog>(saveBlogResource);

            await _blogService.UpdateBlog(blogToBeUpdate, blog);

            var updatedblog = await _blogService.GetBlogById(id);
            var updatedBlogResource = _mapper.Map<Blog, BlogResource>(updatedblog);

            return Ok(updatedBlogResource);
        }
        /// <summary>
        /// API requires JWT auth
        /// </summary>
        /// <returns></returns>
        // DELETE api/blog/1
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            if (id == 0)
                return BadRequest();

            var blog = await _blogService.GetBlogById(id);

            if (blog == null)
                return NotFound();

            await _blogService.DeleteBlog(blog);

            return NoContent();
        }

    }
}