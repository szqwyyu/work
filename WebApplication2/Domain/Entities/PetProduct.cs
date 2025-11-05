using System;
using WebApplication1.Domain.Enums; // Добавлено пространство имен для PetType

namespace WebApplication1.Domain.Entities
{
    public class PetProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public PetType PetType { get; set; }
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}