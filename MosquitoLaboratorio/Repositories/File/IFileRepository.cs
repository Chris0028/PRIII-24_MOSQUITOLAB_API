using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.File
{
    public interface IFileRepository
    {
        Task<int> CreateFile(CreateFileDTO fileDto);
        Task<int> UpdateFile(UpdateFileDTO fileDto);
        Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID);
        Task<List<HistoryFileDTO>> GetHistoryForLab(int laboratoryID);
        Task<long> GetLastFileId();
    }
}
