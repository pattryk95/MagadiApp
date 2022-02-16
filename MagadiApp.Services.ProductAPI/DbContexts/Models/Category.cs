using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagadiApp.Services.ProductAPI.DbContexts.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
