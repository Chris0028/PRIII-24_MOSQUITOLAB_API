using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.File
{
    public interface IFileRepository
    {
        Task<int> CreateFile(CreateFileDTO fileDto);
        Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID);
        Task<List<HistoryFileDTO>> GetHistoryByLabId(int laboratoryID);
        Task<long> GetLastFileId();
    }
}
