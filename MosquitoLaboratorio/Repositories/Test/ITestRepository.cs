using MosquitoLaboratorio.Dtos.Test;
using MosquitoLaboratorio.Entities;

namespace MosquitoLaboratorio.Repositories.Test
{
    public interface ITestRepository
    {
        public Task<UpdateTestSampleDTO> UpdateTestSample(long fileId, UpdateTestSampleDTO dto);
    }
}
