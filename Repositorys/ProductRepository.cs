using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;
using ShopAPI.Repositorys.Interfaces;

namespace ShopAPI.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ProductModel Add(ProductModel product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            return product;
        }

        public List<ProductModel> GetAll()
        {
            List<ProductModel> products = _dataContext.Products.ToList();
            return products;
        }

        public List<ProductModel> GetByCategoryId(int id)
        {
            List<ProductModel> product = _dataContext.Products.Include(x => x.Category).AsNoTracking().Where(x => x.CategoryId == id).ToList();
            return product;
        }

        public ProductModel GetById(int id)
        {
            ProductModel product = _dataContext.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
