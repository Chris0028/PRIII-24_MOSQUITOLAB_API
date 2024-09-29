using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.File
{
    public interface IFileRepository
    {
        Task<int> CreateFile(CreateFileDTO fileDto);
    }
}
