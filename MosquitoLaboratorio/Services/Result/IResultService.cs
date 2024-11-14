using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Services.Result
{
    public interface IResultService
    {
        public Task<ResultViewDTO> GetResultById(long id);
    }
}
