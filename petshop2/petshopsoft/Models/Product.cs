using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}