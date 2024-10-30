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
        Task<FileDetailsDTO> GetFileDetails(long fileId);

        Task<List<HistoryFileDTO>> HistoryFilterByHospitalId(HistoryFileFilterDTO? filterDTO);
        Task<List<HistoryFileDTO>> HistoryFilterByLabId(HistoryFileFilterDTO? filterDTO);

    }
}
