using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;

namespace MosquitoLaboratorio.Services.File
{
    public interface IFileService
    {
        Task<int> CreateFile(CreateFileDTO fileDto);
        Task<int> UpdateFile(UpdateFileDTO fileDto);
        public Task<Tuple<List<HistoryFileDTO>, int>> GetHistoryByHospitalId(long? hospitalID, int page, int limit);
        public Task<Tuple<List<HistoryFileDTO>, int>> GetHistoryByLabId(int? laboratoryID, int page, int limit);
        Task<Tuple<List<HistoryFileDTO>, int>> GetAllHistory(int page, int limit);
        Task<FileDetailsDTO> GetFileDetails(long fileId);
        Task<List<HistoryFileDTO>> HistoryFilterByHospitalId(HistoryFileFilterDTO? filterDTO);
        Task<List<HistoryFileDTO>> HistoryFilterByLabId(HistoryFileFilterDTO? filterDTO);
        public Task<FileWithResultDTO> GetFileWithResult(long fileId);
        public Task<List<ReportFileDTO>> GetReportFileList(ReportFileParametersDTO dto);
        Task<string> GetOrGeneratePatientCode(string? patientCode);

    }
}
