using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;

namespace MosquitoLaboratorio.Services.File
{
    public interface IFileService
    {
        Task<int> CreateFile(CreateFileDTO fileDto);
        Task<int> UpdateFile(UpdateFileDTO fileDto);
        Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID);
        Task<List<HistoryFileDTO>> GetHistoryByLabId(int laboratoryID);
        Task<List<HistoryFileDTO>> GetAllHistory();
        public Task<List<ReportFileDTO>> GetReportFileList(ReportFileParametersDTO dto);
        Task<string> GetOrGeneratePatientCode(string? patientCode);
    }
}
