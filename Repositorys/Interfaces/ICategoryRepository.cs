using ShopAPI.Models;

namespace ShopAPI.Repositorys.Interfaces
{
    public interface ICategoryRepository
    {
        public List<CategoryModel> GetAll();
        public CategoryModel GetById(int id);
        public CategoryModel Add(CategoryModel categoryModel);
        public CategoryModel UpdateCategory(CategoryModel categoryModel, int id);
        public bool Delete(int id);
    }
}
