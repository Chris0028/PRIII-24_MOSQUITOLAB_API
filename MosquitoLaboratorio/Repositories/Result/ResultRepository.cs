using Microsoft.EntityFrameworkCore;
using MosquitoLaboratorio.Data;
using MosquitoLaboratorio.Dtos;

namespace MosquitoLaboratorio.Repositories.Result
{
    public class ResultRepository : IResultRepository
    {
        private readonly LabMosContext _context;

        public ResultRepository(LabMosContext context) => _context = context;

        public async Task<ResultViewDTO> GetResultByID(long id)
        {
            var result = await _context.UfcGetResult.
                               FromSqlInterpolated($"SELECT * FROM ufc_get_result_details({id}::BIGINT)").FirstOrDefaultAsync();

            return result!;
        }
    }
}
