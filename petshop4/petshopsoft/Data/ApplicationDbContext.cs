using System;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ContactMessages> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // УКАЖИТЕ ИМЕНА ТАБЛИЦ ДЛЯ POSTGRESQL
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Services>().ToTable("Services");
            modelBuilder.Entity<ContactMessages>().ToTable("ContactMessages");

            // Конфигурация типов данных для PostgreSQL
            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(p => p.Price)
                      .HasColumnType("numeric(18,2)");
                entity.Property(p => p.Name)
                      .HasMaxLength(100);
                entity.Property(p => p.Category)
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.Property(s => s.Price)
                      .HasColumnType("numeric(18,2)");
                entity.Property(s => s.Title)
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(u => u.Username)
                      .HasMaxLength(50);
                entity.Property(u => u.Email)
                      .HasMaxLength(100);
                entity.Property(u => u.Password)
                      .HasMaxLength(255);
            });

            modelBuilder.Entity<ContactMessages>(entity =>
            {
                entity.Property(c => c.Name)
                      .HasMaxLength(50);
                entity.Property(c => c.Email)
                      .HasMaxLength(100);
                entity.Property(c => c.Message)
                      .HasMaxLength(500);
            });

            // Seed data
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    Name = "Сухой корм для собак",
                    Description = "Премиальный корм для взрослых собак",
                    Price = 25.99m,
                    Category = "Корм",
                    ImageUrl = "/images/dog-food.jpg",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new Products
                {
                    Id = 2,
                    Name = "Лоток для кошек",
                    Description = "Большой комфортный лоток",
                    Price = 15.50m,
                    Category = "Аксессуары",
                    ImageUrl = "/images/cat-litter.jpg",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                },
                new Products
                {
                    Id = 3,
                    Name = "Игрушка для попугаев",
                    Description = "Развивающая игрушка из натуральных материалов",
                    Price = 8.75m,
                    Category = "Игрушки",
                    ImageUrl = "/images/bird-toy.jpg",
                    IsAvailable = true,
                    CreatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Services>().HasData(
                new Services
                {
                    Id = 1,
                    Title = "Стрижка собак",
                    Description = "Профессиональная стрижка всех пород",
                    Price = 45.00m,
                    Duration = 120,
                    ImageUrl = "/images/dog-grooming.jpg",
                    IsActive = true
                },
                new Services
                {
                    Id = 2,
                    Title = "Ветеринарный осмотр",
                    Description = "Полный медицинский осмотр питомца",
                    Price = 35.00m,
                    Duration = 60,
                    ImageUrl = "/images/vet-check.jpg",
                    IsActive = true
                },
                new Services
                {
                    Id = 3,
                    Title = "Дрессировка",
                    Description = "Базовый курс послушания",
                    Price = 60.00m,
                    Duration = 90,
                    ImageUrl = "/images/dog-training.jpg",
                    IsActive = true
                }
            );
        }
    }
}