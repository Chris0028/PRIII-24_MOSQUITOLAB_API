namespace MosquitoLaboratorio.Repositories.Reports
{
    public interface IReportRepository
    {
        Task<Dictionary<string, int>> ReportPatientByGender();
        Task<Dictionary<string, int>> ReportPatientByAge();
    }
}
