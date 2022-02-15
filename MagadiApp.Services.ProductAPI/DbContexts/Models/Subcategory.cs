using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagadiApp.Services.ProductAPI.DbContexts.Models
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }


        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public virtual List<Product> Products { get; set; }
    }
}
