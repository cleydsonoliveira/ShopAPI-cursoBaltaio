using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
using ShopAPI.Repositorys.Interfaces;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAll()
        {
            List<ProductModel> products = _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            ProductModel product = _productRepository.GetById(id);
            return Ok(product);
        }

        [HttpGet("GetByCategoryId/{id:int}")]
        public async Task<ActionResult<List<ProductModel>>> GetByCategoryId(int id)
        {
            List<ProductModel> products = _productRepository.GetByCategoryId(id);
            return Ok(products);
        }
    }
}
