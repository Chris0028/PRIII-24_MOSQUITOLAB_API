using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.Result
{
    public interface IResultRepository
    {
        public Task<ResultViewDTO> GetResultByID(long id);
    }
}
