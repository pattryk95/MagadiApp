using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagadiApp.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
        [Range(1,1000)]
        public double Price { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string? Description { get; set; }


        public int? CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

    }
}
