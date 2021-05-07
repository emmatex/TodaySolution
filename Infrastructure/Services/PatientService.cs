using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task ProcessCsvFile(string path)
        {
            try
            {
                DataTable dt = await ConvertCSVtoDataTable(path);
                var patientList = new List<Patient>();
                var headers = dt.Rows[0].ItemArray;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i].ItemArray;
                    var item = new Patient();
                    item.Id = Guid.NewGuid().ToString();
                    item.PatientName = dr[0].ToString();
                    item.BloodGroup = dr[1].ToString();
                    item.PhoneNumber = dr[2].ToString();
                    item.TreatmentDetails = dr[3].ToString();
                    item.DateOfBirth = Convert.ToDateTime(dr[4]);
                    item.Age = Convert.ToInt32(dr[5]);
                    item.Date = Convert.ToDateTime(dr[6]);
                    item.DoctorName = dr[6].ToString();
                    item.Charge = Convert.ToDecimal(dr[6]);

                    patientList.Add(item);
                }
                await _repository.AddRangeAsync(patientList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Task<DataTable> ConvertCSVtoDataTable(string path)
        {
            var dt = new DataTable();
            using (StreamReader sr = new StreamReader(path))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    if (rows.Length > 1)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i].Trim();
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            return Task.FromResult(dt);
        }


    }
}
