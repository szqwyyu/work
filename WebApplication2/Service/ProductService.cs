using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(PetProduct product)
        {
            await _repo.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<PetProduct>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<PetProduct?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PetProduct>> GetByPetTypeAsync(PetType petType)
        {
            var all = await _repo.GetAllAsync();
            return all.Where(p => p.PetType == petType);
        }

        public async Task UpdateAsync(PetProduct product)
        {
            await _repo.UpdateAsync(product);
        }
    }
}