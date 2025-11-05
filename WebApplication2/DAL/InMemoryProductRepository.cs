using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Enums;

namespace WebApplication1.DAL
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<int, PetProduct> _store = new();
        private int _idCounter = 0;

        public InMemoryProductRepository()
        {
            // Seed some sample products
            AddAsync(new PetProduct
            {
                Name = "Сухой корм для собак - 3kg",
                Description = "Сбалансированный корм для взрослых собак.",
                Price = 1299.50m,
                PetType = PetType.Dog,
                Category = "Корм",
                ImageUrl = "/images/dog-food-3kg.jpg"
            }).Wait();

            AddAsync(new PetProduct
            {
                Name = "Игрушка для кота - мышка",
                Description = "Плюшевая мышь с кошачьей мятой.",
                Price = 199.00m,
                PetType = PetType.Cat,
                Category = "Игрушки",
                ImageUrl = "/images/cat-toy-mouse.jpg"
            }).Wait();
        }

        public Task AddAsync(PetProduct product)
        {
            var id = System.Threading.Interlocked.Increment(ref _idCounter);
            product.Id = id;
            _store[id] = product;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            _store.TryRemove(id, out _);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<PetProduct>> GetAllAsync()
        {
            var items = _store.Values.OrderBy(p => p.Id).AsEnumerable();
            return Task.FromResult(items);
        }

        public Task<PetProduct?> GetByIdAsync(int id)
        {
            _store.TryGetValue(id, out var product);
            return Task.FromResult(product);
        }

        public Task UpdateAsync(PetProduct product)
        {
            if (product == null || product.Id == 0)
                return Task.CompletedTask;
            _store[product.Id] = product;
            return Task.CompletedTask;
        }
    }
}