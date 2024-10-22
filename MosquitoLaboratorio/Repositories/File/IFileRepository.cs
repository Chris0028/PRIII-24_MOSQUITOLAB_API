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
        public Task<List<HistoryFileDTO>> GetHistoryForLab(int laboratoryID);
        public Task<long> GetLastFileId();
    }
}
