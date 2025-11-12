using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public int Duration { get; set; } // in minutes
        public bool IsActive { get; set; } = true;
    }
}