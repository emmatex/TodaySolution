using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(string id);
        Task<IReadOnlyList<Patient>> GetAsync();
        Task AddAsync(Patient patient);
        Task AddRangeAsync(List<Patient> patients);
    }
}
