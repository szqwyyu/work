using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Service.Interfaces;

namespace WebApplication1.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task CreateAsync(Product product)
        {
            // Простейшая бизнес-валидация
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Name is required", nameof(product.Name));

            product.CreatedAt = DateTime.UtcNow;
            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            product.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}