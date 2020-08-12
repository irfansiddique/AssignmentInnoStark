using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using innoStarkAssignment.Api.Resources;
using innoStarkAssignment.Api.Validators;
using innoStarkAssignment.Core.Model;
using innoStarkAssignment.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace innoStarkAssignment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this._mapper = mapper;
            this._categoryService = categoryService;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResource>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            var categoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return Ok(categoryResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResource>> GetCategoryById(int id)
        {
            var Category = await _categoryService.GetCategoryById(id);
            var CategoryResource = _mapper.Map<Category, CategoryResource>(Category);

            return Ok(CategoryResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CategoryResource>> CreateCategory([FromBody] SaveCategoryResource SaveCategoryResource)
        {
            var validator = new SaveCategoryResourceValidator();
            var validationResult = await validator.ValidateAsync(SaveCategoryResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var categoryToCreate = _mapper.Map<SaveCategoryResource, Category>(SaveCategoryResource);

            var newCategory = await _categoryService.CreateCategory(categoryToCreate);

            var Category = await _categoryService.GetCategoryById(newCategory.Id);

            var CategoryResource = _mapper.Map<Category, CategoryResource>(Category);

            return Ok(CategoryResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryResource>> UpdateCategory(int id, [FromBody] SaveCategoryResource SaveCategoryResource)
        {
            var validator = new SaveCategoryResourceValidator();
            var validationResult = await validator.ValidateAsync(SaveCategoryResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);  

            var categoryToBeUpdated = await _categoryService.GetCategoryById(id);

            if (categoryToBeUpdated == null)
                return NotFound();

            var Category = _mapper.Map<SaveCategoryResource, Category>(SaveCategoryResource);

            await _categoryService.UpdateCategory(categoryToBeUpdated, Category);

            var updatedCategory = await _categoryService.GetCategoryById(id);

            var updatedCategoryResource = _mapper.Map<Category, CategoryResource>(updatedCategory);

            return Ok(updatedCategoryResource);
        }
        /// <summary>
        /// API requires JWT auth
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Category = await _categoryService.GetCategoryById(id);

            await _categoryService.DeleteCategory(Category);

            return NoContent();
        }
    }
}