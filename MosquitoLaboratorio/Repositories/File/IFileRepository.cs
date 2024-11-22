using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.File
{
    public interface IFileRepository
    {
        public Task<int> CreateFile(CreateFileDTO fileDto);
        public Task<int> UpdateFile(UpdateFileDTO fileDto);
        public Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long? hospitalID, int offset, int limit);
        public Task<int> CountAllHos(long? hospitalID);
        public Task<List<HistoryFileDTO>> GetHistoryByLabId(int? laboratoryID, int offset, int limit);
        public Task<int> CountAllLab(int? laboratoryID);
        public Task<List<HistoryFileDTO>> GetAllHistory(int offset, int limit);
        public Task<int> CountAllHistory();
        public Task<long> GetLastFileId();
        public Task<FileDetailsDTO> GetFileDetails(long fileId);
        public Task<List<ReportFileDTO>> GetReportFileList(ReportFileParametersDTO dto);
        public Task<bool> PatientCodeExists(string patientCode);
        public Task<string?> GetLastPatientCode();
        public Task<string> GetCode(string ci);
        public Task<FileWithResultDTO> GetFileWithResult(long fileId);
        public Task<List<HistoryFileDTO>> HistoryFilterByHospitalId(HistoryFileFilterDTO? filterDTO);
        public Task<List<HistoryFileDTO>> HistoryFilterByLabId(HistoryFileFilterDTO? filterDTO);
        public Task<bool> HasPendingFileByCI(string patientCI, int diseaseId);
        public Task<string> lastFileCode(int diseaseId);
    }
}
