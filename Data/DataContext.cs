using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
