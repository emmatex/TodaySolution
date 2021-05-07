using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(string id);
        IEnumerable<Patient> GetAsync(int page, int pageSize);
        Task AddAsync(Patient patient);
        Task AddRangeAsync(List<Patient> patients);
        Task<bool> SaveChangesAsync();
    }
}
