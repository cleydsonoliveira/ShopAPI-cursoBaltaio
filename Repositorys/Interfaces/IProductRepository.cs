using ShopAPI.Models;

namespace ShopAPI.Repositorys.Interfaces
{
    public interface IProductRepository
    {
        public List<ProductModel> GetAll();
        public ProductModel GetById(int id);
        public List<ProductModel> GetByCategoryId(int id);
        public ProductModel Add(ProductModel product);
    }
}
