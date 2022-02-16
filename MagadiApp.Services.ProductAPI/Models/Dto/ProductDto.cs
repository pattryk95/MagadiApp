namespace MagadiApp.Services.ProductAPI.Models.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public CategoryDto? CategoryDto { get; set; }
    }
}
