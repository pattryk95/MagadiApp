/*
using MagadiApp.Services.ProductAPI.DbContexts;
using MagadiApp.Services.ProductAPI.DbContexts.Models;

namespace MagadiApp.Services.ProductAPI
{
    public class ProductSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products)
                };
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "xx"
                }
            }
        }
    }
}
*/