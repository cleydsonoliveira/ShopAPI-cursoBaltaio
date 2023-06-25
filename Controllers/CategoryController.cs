using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Repositorys.Interfaces;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAll()
        {
            List<CategoryModel> categories = _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<CategoryModel>> GetById(int id)
        {
            CategoryModel category = _categoryRepository.GetById(id);
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> Add([FromBody] CategoryModel category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            _categoryRepository.Add(category);
            return Ok(category);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryModel>> Update([FromBody] CategoryModel categoryModel, int id)
        {
            if (categoryModel == null || id == null)
            {
                return BadRequest();
            }
            _categoryRepository.UpdateCategory(categoryModel, id);
            return Ok(categoryModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = _categoryRepository.Delete(id);
            if (deleted)
            {
                return Ok("Categoria deletada com sucesso");
            }
            return BadRequest();
        }
    }
}
