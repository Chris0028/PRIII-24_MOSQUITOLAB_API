
using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;

namespace MosquitoLaboratorio.Repositories.Reports
{
    public class ReportRepository : IReportRepository
    {
        private readonly LabMosContext _context;

        public ReportRepository(LabMosContext context) => _context = context;



        public async Task<Dictionary<string, int>> ReportPatientByGender()
        {
            var maleCount = await _context.Patients.CountAsync(p => p.Gender == 'M');
            var femaleCount = await _context.Patients.CountAsync(p => p.Gender == 'F');

            return new Dictionary<string, int>
            {
                { "Male", maleCount },
                { "Female", femaleCount }
            };
        }

        public async Task<Dictionary<string, int>> ReportPatientByAge()
        {
            var today = DateTime.SpecifyKind(DateTime.UtcNow.Date, DateTimeKind.Utc); // Asegurarse de que sea UTC

            var minorsCount = await _context.Patients
                .CountAsync(p => today.Year - p.BirthDate.Year -
                                 (today < p.BirthDate.AddYears(today.Year - p.BirthDate.Year) ? 1 : 0) < 18);

            var adultsCount = await _context.Patients
                .CountAsync(p => today.Year - p.BirthDate.Year -
                                 (today < p.BirthDate.AddYears(today.Year - p.BirthDate.Year) ? 1 : 0) >= 18);

            // Retornar como diccionario con las claves "Menor" y "Mayor"
            return new Dictionary<string, int>
            {
                { "Menor", minorsCount },   
                { "Mayor", adultsCount }
            };
        }
    }
}
