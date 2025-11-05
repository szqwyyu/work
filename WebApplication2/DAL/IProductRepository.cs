using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities;

namespace WebApplication1.DAL
{
    public interface IProductRepository
    {
        Task<IEnumerable<PetProduct>> GetAllAsync();
        Task<PetProduct?> GetByIdAsync(int id);
        Task AddAsync(PetProduct product);
        Task UpdateAsync(PetProduct product);
        Task DeleteAsync(int id);
    }
}