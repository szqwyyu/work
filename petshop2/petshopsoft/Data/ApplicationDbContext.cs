using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Сухой корм для собак", Description = "Премиальный корм для взрослых собак", Price = 25.99m, Category = "Корм", ImageUrl = "/images/dog-food.jpg" },
                new Product { Id = 2, Name = "Лоток для кошек", Description = "Большой комфортный лоток", Price = 15.50m, Category = "Аксессуары", ImageUrl = "/images/cat-litter.jpg" },
                new Product { Id = 3, Name = "Игрушка для попугаев", Description = "Развивающая игрушка из натуральных материалов", Price = 8.75m, Category = "Игрушки", ImageUrl = "/images/bird-toy.jpg" }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Title = "Стрижка собак", Description = "Профессиональная стрижка всех пород", Price = 45.00m, Duration = 120, ImageUrl = "/images/dog-grooming.jpg" },
                new Service { Id = 2, Title = "Ветеринарный осмотр", Description = "Полный медицинский осмотр питомца", Price = 35.00m, Duration = 60, ImageUrl = "/images/vet-check.jpg" },
                new Service { Id = 3, Title = "Дрессировка", Description = "Базовый курс послушания", Price = 60.00m, Duration = 90, ImageUrl = "/images/dog-training.jpg" }
            );
        }
    }
}