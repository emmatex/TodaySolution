using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        }

        public async Task AddRangeAsync(List<Patient> patients)
        {
           await _context.Patients.AddRangeAsync(patients);
        }

        public async Task<IReadOnlyList<Patient>> GetAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
