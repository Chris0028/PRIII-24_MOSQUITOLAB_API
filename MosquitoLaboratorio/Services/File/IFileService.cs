using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Services.File
{
    public interface IFileService
    {
        Task<int> CreateFile(CreateFileDTO fileDto);
    }
}
