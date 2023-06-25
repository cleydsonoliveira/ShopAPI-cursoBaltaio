using ShopAPI.Data;
using ShopAPI.Models;
using ShopAPI.Repositorys.Interfaces;

namespace ShopAPI.Repositorys
{
    public class CaregoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CaregoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<CategoryModel> GetAll()
        {
            List<CategoryModel> categories = _dataContext.Categories.ToList();
            return categories;
        }

        public CategoryModel GetById(int id)
        {
            CategoryModel category = _dataContext.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                throw new Exception($"Categoria com o id: {id} não encontrada");
            }
            return category;
        }

        public CategoryModel Add(CategoryModel categoryModel)
        {
            _dataContext.Categories.Add(categoryModel);
            _dataContext.SaveChanges();
            return categoryModel;
        }

        public CategoryModel UpdateCategory(CategoryModel categoryModel, int id)
        {
            CategoryModel category = GetById(id);
            if (category == null)
            {
                throw new Exception($"Categoria com o id: {id} não encontrada, não foi possivel atualizar a sua categoria");
            }
            category.Id = id;
            category.Title = categoryModel.Title;

            _dataContext.Categories.Update(category);
            _dataContext.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
            CategoryModel category = GetById(id);
            _dataContext.Categories.Remove(category);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
