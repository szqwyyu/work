using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Service
{
    public interface IProductService
    {
        Task<IEnumerable<PetProduct>> GetAllAsync();
        Task<IEnumerable<PetProduct>> GetByPetTypeAsync(PetType petType);
        Task<PetProduct?> GetByIdAsync(int id);
        Task AddAsync(PetProduct product);
        Task UpdateAsync(PetProduct product);
        Task DeleteAsync(int id);
    }
}