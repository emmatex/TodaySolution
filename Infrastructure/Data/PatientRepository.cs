using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _context;

        public PatientRepository(PatientContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<Patient> patients)
        {
            await _context.Patients.AddRangeAsync(patients);
            await SaveChangesAsync();
        }

        public IEnumerable<Patient> GetAsync(int page, int pageSize)
        {
            return _context.Patients
                .AsQueryable().Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.PatientName)
                .ThenBy(x => x.DateOfBirth)
                .ToList();
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            return await _context.Patients.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
