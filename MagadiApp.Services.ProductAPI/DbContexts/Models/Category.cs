using System.ComponentModel.DataAnnotations;

namespace MagadiApp.Services.ProductAPI.DbContexts.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
