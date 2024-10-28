using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.File
{
    public interface IFileRepository
    {
        public Task<int> CreateFile(CreateFileDTO fileDto);
        public Task<int> UpdateFile(UpdateFileDTO fileDto);
        public Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID);
        public Task<List<HistoryFileDTO>> GetHistoryByLabId(int laboratoryID);
        public Task<List<HistoryFileDTO>> GetAllHistory();
        public Task<long> GetLastFileId();
        public Task<FileDetailsDTO> GetFileDetails(long fileId);
    }
}
