using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPatientService
    {
        Task ProcessCsvFile(string path);
    }
}
