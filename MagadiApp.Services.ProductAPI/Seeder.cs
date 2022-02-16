using MagadiApp.Services.ProductAPI.DbContexts;
using MagadiApp.Services.ProductAPI.DbContexts.Models;

namespace MagadiApp.Services.ProductAPI
{
    public class Seeder
    {
        private readonly ApplicationDbContext _dbContext;

        public Seeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Categories.Any())
                {
                    var categories = DataScraper.GetCategory();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Products.Any())
                {
                    var products = DataScraper.GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
        }


    }
}