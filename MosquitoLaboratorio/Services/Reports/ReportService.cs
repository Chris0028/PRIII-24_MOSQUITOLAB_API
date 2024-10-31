
using MosquitoLaboratorio.Repositories.Reports;

namespace MosquitoLaboratorio.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        public ReportService(IReportRepository repository) => _repository = repository;

        public async Task<Dictionary<string, int>> ReportPatientByGender()
        {
            var patients = await _repository.ReportPatientByGender();

            if (patients != null)
                return patients;

            return null!;
        }

        public async Task<Dictionary<string, int>> ReportPatientByAge()
        {
            var patients = await _repository.ReportPatientByAge();

            if (patients != null)
                return patients;

            return null!;
        }
    }
}
