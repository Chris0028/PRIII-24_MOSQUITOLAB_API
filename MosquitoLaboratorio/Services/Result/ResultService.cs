using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Repositories.Result;

namespace MosquitoLaboratorio.Services.Result
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;

        public ResultService(IResultRepository resultRepository) => _resultRepository = resultRepository;

        public async Task<ResultViewDTO> GetResultById(long id)
        {
            var result = await _resultRepository.GetResultByID(id);

            if (result == null)
                return null!;

            return result!;
        }
    }
}
