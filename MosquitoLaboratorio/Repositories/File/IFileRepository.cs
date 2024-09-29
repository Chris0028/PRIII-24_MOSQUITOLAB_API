using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.File
{
    public interface IFileRepository
    {
        Task<int> CreateFile(CreateFileDTO fileDto);
        Task<List<HistoryFileDTO>> GetHistoryByHospitalId(long hospitalID);
        Task<List<HistoryFileDTO>> GetHistoryByLabId(int laboratoryID);
    }
}
