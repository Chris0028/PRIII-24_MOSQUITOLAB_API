namespace MosquitoLaboratorio.Services.Reports
{
    public interface IReportService
    {
        public Task<Dictionary<string, int>> ReportPatientByGender();
        public Task<Dictionary<string, int>> ReportPatientByAge();

    }
}
